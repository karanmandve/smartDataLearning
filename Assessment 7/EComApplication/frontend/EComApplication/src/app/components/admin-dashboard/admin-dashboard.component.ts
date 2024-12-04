import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../services/product/product.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
declare var bootstrap: any;

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  userDetails = JSON.parse(localStorage.getItem('userDetails') || '{}');
  products: any[] = [];
  isEditing = false;
  selectedProduct: any = null;

  @ViewChild('productModel') productModel!: ElementRef;
  toaster = inject(ToastrService)

  productService = inject(ProductService)

  ngOnInit(): void {
    this.loadProducts();
  }

  productForm: FormGroup = new FormGroup({
    productName: new FormControl('', [Validators.required]),
    productCode: new FormControl('', [Validators.required]),
    imageFile: new FormControl<File | null>(null),
    category: new FormControl('', [Validators.required]),
    brand: new FormControl('', [Validators.required]),
    sellingPrice: new FormControl('', [Validators.required, Validators.min(1)]),
    purchasePrice: new FormControl('', [Validators.required, Validators.min(1)]),
    purchaseDate: new FormControl('', [Validators.required]),
    stock: new FormControl('', [Validators.required, Validators.min(1)]),
    userId: new FormControl(0)
  });


  // Fetch all products from API
  loadProducts() {
    this.productService.getAllProductByUserId(this.userDetails.id).subscribe(
      (data: any) => {
        this.products = data;
        console.log('Products:', data);
      },
      (error: any) => {
        console.error('Error fetching products:', error);
      }
    );
  }

    // Show details of a product
    showDetails(product: any) {
      this.selectedProduct = product;
      const detailsModal = new bootstrap.Modal(document.getElementById('detailsModal')!);
      detailsModal.show();
    }

  // Open Add/Edit Modal
  openModal(product: any = null) {
    this.isEditing = !!product;
    this.selectedProduct = product;

    if (this.isEditing) {
      // Populate form with selected product data
      this.productForm.patchValue(product);
    } else {
      this.productForm.reset();
    }

    const modal = document.getElementById('productModal');
    if (modal) {
      modal.classList.add('show');
      modal.style.display = 'block';
    }
  }

  // Close Modal
  closeModal() {
    const modal = document.getElementById('productModal');
    if (modal) {
      modal.classList.remove('show');
      modal.style.display = 'none';
    }
    this.productForm.reset();
    this.isEditing = false;
    this.selectedProduct = null;
  }


  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      // Update form control with selected file
      this.productForm.patchValue({ imageFile: file });
      this.productForm.get('imageFile')?.updateValueAndValidity();
    }
  }


  saveProduct() {
    if (this.productForm.invalid) {
      return;
    }

    const formData = new FormData();

    Object.keys(this.productForm.controls).forEach(field => {
      const value = this.productForm.get(field)?.value;
      if (field === "userId") {
        formData.append(field, this.userDetails.id);
      }else{
        formData.append(field, value);
      }
    });

    if (this.isEditing && this.selectedProduct) {
      formData.append('id', this.selectedProduct.id);
      this.productService.updateProduct(formData).subscribe(
        () => {
          this.toaster.success('Product updated successfully', 'Success');
          this.loadProducts();
          this.closeModal();
        },
        (error) => {
          this.toaster.error('Error updating product', 'Error');
          console.error('Error updating product:', error)
        }
      );
    } else {
      this.productService.addProduct(formData).subscribe(
        () => {
          this.toaster.success('Product added successfully', 'Success');
          this.loadProducts();
          this.closeModal();
        },
        (error) => {
          this.toaster.error('Error adding product', 'Error');
          console.error('Error adding product:', error)}
      );
    }
  }

  // Delete Product
  deleteProduct(productId: number) {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProductById(productId).subscribe(
        () => {
          this.toaster.success('Product deleted successfully', 'Success');
          this.loadProducts()
        },
        (error) => {
          this.toaster.error('Error deleting product', 'Error');
          console.error('Error deleting product:', error)
        }
      );
    }
  }
}
