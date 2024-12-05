import { Component, inject } from '@angular/core';
import { CartService } from '../../services/cart/cart.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  cartProducts: any[] = [];
  totalPrice: number = 0;
  userDetails = JSON.parse(localStorage.getItem('userDetails') || '{}');
  addressData: any;
  invoiceUrl: any;

  cartService = inject(CartService);
  toaster = inject(ToastrService)

  ngOnInit(): void {
    this.loadCart();
  }

  addressForm: FormGroup = new FormGroup({
    address: new FormControl('', [Validators.required]),
    zipcode: new FormControl('', [Validators.required]),
    state: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required])
  });
  
  paymentForm: FormGroup = new FormGroup({
    cardNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{16}$')]),
    expiryDate: new FormControl('', [Validators.required, Validators.pattern('^(0[1-9]|1[0-2])\/[0-9]{2}$')]),
    cvv: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{3}$')])
  });


  loadCart() {
    const userId = this.userDetails.id; // replace with actual user ID
    this.cartService.getCartProduct(userId).subscribe((data: any) => {
      this.cartProducts = data;
      this.calculateTotalPrice();
      localStorage.removeItem('cart');
      var cart = new Set<number>();
      this.cartProducts.forEach((product) => {
        cart.add(product.productId);
      });
      localStorage.setItem('cart', JSON.stringify(Array.from(cart)));
    });
  }

  removeProductFromCart(product: any) {
    this.cartService.removeProductFromCart(product.productId, this.userDetails.id).subscribe(() => {
      this.loadCart();
      this.cartService.updateCartCount(this.userDetails.id);
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
      this.toaster.warning("Stock Is Over", "Warning");
    }
  });
  }

  calculateTotalPrice() {
    this.totalPrice = this.cartProducts.reduce(
      (sum, product) => sum + product.sellingPrice * product.quantity,
      0
    );
  }


  openAddressPopup() {

    if (this.userDetails.address) {
      this.addressForm.patchValue({
        address: this.userDetails.address,
        zipcode: this.userDetails.zipcode,
        state: this.userDetails.stateId,
        country: this.userDetails.countryId
      });
    }
    // Show the modal by adding the class
    const modal = document.getElementById('addressModal');
    if (modal) {
      modal.classList.add('show');
      modal.style.display = 'block';
    }
  }


  saveAddress() {

      this.addressData = this.addressForm.value;

    this.closeModal('addressModal');
    this.openPaymentPopup();
  }

  openPaymentPopup() {
    // Show the payment modal
    const modal = document.getElementById('paymentModal');
    if (modal) {
      modal.classList.add('show');
      modal.style.display = 'block';
    }
  }

  closeModal(modalId: string) {
    const modal = document.getElementById(modalId);
    if (modal) {
      modal.classList.remove('show');
      modal.style.display = 'none';
    }
  }

  makePayment() {
    console.log("i am outside");
    
 

      const paymentData = {
        ...this.paymentForm.value,
        userId: this.userDetails.id,
        deliveryAddress: this.addressData.address,
        deliveryZipcode: this.addressData.zipcode,
        deliveryStateId: this.addressData.state,
        deliveryCountryId: this.addressData.country
      };

      this.cartService.makePayment(paymentData).subscribe((res: any) => {

        this.invoiceUrl = res.invoiceUrl;
        
        
        this.cartService.updateCartCount(this.userDetails.id);
        this.closeModal('paymentModal');
        this.openSuccessPopup();
      });

  }


  openSuccessPopup() {
    const modal = document.getElementById('successModal');
    if (modal) {
      modal.classList.add('show');
      modal.style.display = 'block';
    }
    const iframe = document.createElement('iframe');
    iframe.style.display = 'none';  // Make the iframe invisible
    iframe.src = this.invoiceUrl;
    document.body.appendChild(iframe);  // Append it to the body to load the URL in the background

    // Optional: Remove iframe after loading
    iframe.onload = () => {
        document.body.removeChild(iframe);
    };
    this.loadCart();
  }
}
