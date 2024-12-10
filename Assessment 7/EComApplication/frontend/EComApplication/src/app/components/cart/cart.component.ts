import { Component, inject } from '@angular/core';
import { CartService } from '../../services/cart/cart.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CountryStateServiceService } from '../../services/country-state-service/country-state-service.service';

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
  toaster = inject(ToastrService);
  countryStateService: any = inject(CountryStateServiceService);

  ngOnInit(): void {
    this.getAllCountry();
    // this.loadState();
    this.loadCart();
  }

  addressForm: FormGroup = new FormGroup({
    address: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(150), Validators.pattern(/^[a-zA-Z0-9\s,.-]+$/)]),
    zipcode: new FormControl('', [Validators.required, Validators.pattern(/^\d{6}$/), Validators.minLength(6), Validators.maxLength(6)]),
    state: new FormControl(0, [Validators.required]),
    country: new FormControl(0, [Validators.required])
  });
  
  paymentForm: FormGroup = new FormGroup({
    cardNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{16}$')]),
    expiryYear: new FormControl('', [Validators.required]),
    expiryMonth: new FormControl('', [Validators.required]),
    cvv: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{3}$')])
  });

  months = [
    { value: '01', label: '01' },
    { value: '02', label: '02' },
    { value: '03', label: '03' },
    { value: '04', label: '04' },
    { value: '05', label: '05' },
    { value: '06', label: '06' },
    { value: '07', label: '07' },
    { value: '08', label: '08' },
    { value: '09', label: '09' },
    { value: '10', label: '10' },
    { value: '11', label: '11' },
    { value: '12', label: '12' }
  ];

  
  currentYear = new Date().getFullYear();
  years = Array.from({ length: 20 }, (_, i) => this.currentYear + i);

  onKeyPress(event: KeyboardEvent) {
    const charCode = event.which ? event.which : event.keyCode;

    if (charCode < 48 || charCode > 57) {
      event.preventDefault(); 
    }
  }

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
        country: this.userDetails.countryId,
        state: this.userDetails.stateId
      });
    }

    this.getState(this.userDetails.countryId);
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
    
      var paymentFormData = this.paymentForm.value;

      var expiryDate = `${paymentFormData.expiryMonth}/${paymentFormData.expiryYear}`;

      const paymentData = {
        cardNumber : paymentFormData.cardNumber,
        cvv : paymentFormData.cvv,
        expiryDate: expiryDate,
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




  allCountry : any [] = []


  getAllCountry(){
    this.countryStateService.getAllCountry().subscribe({
      next : (res: any) => {
        this.allCountry = res
      },
      error : (error: any) =>{
        alert("I am in error")
      }
      
    })
  }


  allState : any [] = []


  // loadState(){
  //   this.countryStateService.getAllState().subscribe({
  //     next : (res:any) => {
  //       this.allState = res
  //     },
  //     error : (error: any) => {
  //       alert("I am in error")
  //     }
  //   })
  // }

  getState(countrId : any){
    this.countryStateService.getStateByCountryId(countrId).subscribe({
      next : (res:any) => {
        this.allState = res
      },
      error : (error: any) => {
        alert("I am in error")
      }
    })
  }




  getCountryName(countryId: number): string {
    const country = this.allCountry.find(c => c.countryId === countryId);
    return country ? country.name : 'Not Found';
  }

  getStateName(stateId: number): string {
    const state = this.allState.find(s => s.stateId === stateId);
    return state ? state.name : 'Not Found';
  }


}
