import { Component, inject } from '@angular/core';
import { ProductService } from '../../services/product/product.service';
import { CommonModule } from '@angular/common';
import { CartService } from '../../services/cart/cart.service';
declare var bootstrap: any;

@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './customer-dashboard.component.html',
  styleUrl: './customer-dashboard.component.css'
})
export class CustomerDashboardComponent {
  products: any[] = [];  // Store the products
  selectedProduct: any;  // To store selected product details for the modal

  // Injecting the ProductService
  productService = inject(ProductService);
  cartService = inject(CartService);

  ngOnInit() {
    this.getAllProducts();
    this.cartService.resetCartCount();
  }

  // Fetch all products from the service
  getAllProducts() {
    this.productService.getAllProduct().subscribe({
      next: (data: any) => {
        console.log('Products:', data);
        this.products = data;  // Store the products data in the array
      },
      error: (error: any) => {
        console.error('Error fetching products:', error);
      }
    });
  }

  // Method to open the modal with product details
  openModal(product: any) {
    this.selectedProduct = product;  // Assign the selected product data
    const modal = new bootstrap.Modal(document.getElementById('productDetailsModal') as HTMLElement);
    modal.show();  // Show the modal
  }


  addToCart(product: any) {
    product.isAddedToCart = true; // Mark the product as added
    this.cartService.incrementCartCount(); // Update the global cart counter
  }

}
