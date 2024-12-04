import { Component, inject } from '@angular/core';
import { CartService } from '../../services/cart/cart.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  cartProducts: any[] = [];
  totalPrice: number = 0;
  userDetails = JSON.parse(localStorage.getItem('userDetails') || '{}');

  cartService = inject(CartService);

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart() {
    const userId = this.userDetails.id; // replace with actual user ID
    this.cartService.getCartProduct(userId).subscribe((data: any) => {
      this.cartProducts = data;
      this.calculateTotalPrice();
    });
  }

  incrementQuantity(product: any) {
    this.updateCartQuantity(product, 1);
  }

  decrementQuantity(product: any) {
    this.updateCartQuantity(product, -1);
  }

  updateCartQuantity(product: any, quantity: any) {
    const cartQuantityData = {
      userId: this.userDetails.id,
      productId: product.productId,
      quantityChange: quantity  // Increment by 1 or decrement by 1
    };

    this.cartService.updateCartQuantity(cartQuantityData).subscribe({
      next: (response) => {
      this.loadCart() 
      this.cartService.updateCartCount(this.userDetails.id);
    }, 
    error: (error) => {
      console.error('Error updating cart', error);
    }
  });
  }

  calculateTotalPrice() {
    this.totalPrice = this.cartProducts.reduce(
      (sum, product) => sum + product.sellingPrice * product.quantity,
      0
    );
  }

  pay() {
    console.log('Initiating payment process');
    // Implement your payment logic here
  }
}
