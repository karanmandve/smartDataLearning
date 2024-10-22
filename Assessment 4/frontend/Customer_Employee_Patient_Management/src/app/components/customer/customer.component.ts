import { Component, inject, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  MinLengthValidator,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CustomerServiceService } from '../../services/customer-service/customer-service.service';
import { CommonModule, JsonPipe } from '@angular/common';
import { dateTimestampProvider } from 'rxjs/internal/scheduler/dateTimestampProvider';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, JsonPipe],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css',
})
export class CustomerComponent implements OnInit {
  customerService = inject(CustomerServiceService);
  toaster: any = inject(ToastrService);
  allCustomer: any[] = [];

  /**
   *
   */
  constructor() {
    this.getCustomers();
  }

  ngOnInit(): void {
    this.getCustomers();
  }

  updatedMode: boolean = false;

  customerForm: FormGroup = new FormGroup({
    customerId: new FormControl(0),
    firstName: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    lastName: new FormControl(''),
    age: new FormControl([Validators.minLength(1), Validators.maxLength(130)]),
    email: new FormControl('', [Validators.email]),
    phoneNumber: new FormControl(''),
    address: new FormControl(''),
    city: new FormControl(''),
    state: new FormControl(''),
    country: new FormControl(''),
    postalCode: new FormControl(''),
    gender: new FormControl(''),
    birthday: new FormControl(''),
    customerSince: new FormControl(""),
    isMembershipActive: new FormControl(false),
    totalSpent: new FormControl(0),
    lastPurchaseDate: new FormControl(""),
    preferredLanguage: new FormControl(''),
    customerStatus: new FormControl(''),
    customerRating: new FormControl(0),
    isCustomerActive : new FormControl(true)
  });

  resetForm() {
    this.customerForm.reset({
      customerId: 0,
      firstName: '',
      lastName: '',
      age: 0,
      email: '',
      phoneNumber: '',
      address: '',
      city: '',
      state: '',
      country: '',
      postalCode: '',
      gender: '',
      birthday: '',
      customerSince: "",
      isMembershipActive: false,
      totalSpent: 0,
      lastPurchaseDate: "",
      preferredLanguage: '',
      customerStatus: '',
      customerRating: 0,
      isCustomerActive: true
    });
  }

  formValue: any;

  onSubmit() {
    this.formValue = this.customerForm.value;
    this.addCustomers(this.formValue);
    this.resetForm();
  }
  showSucess(message: string) {
    this.toaster.success(message, 'sucess', {
      closeButton: true,
    });
  }

  getCustomers() {
    this.customerService.getAllCustomer().subscribe({
      next: (res: any) => {
        this.allCustomer = res;
      },
      error: (error) => {
        alert(error);
      },
    });
  }

  addCustomers(customer: any) {
    this.customerService.addCustomer(customer).subscribe({
      next: (res) => {
        this.showSucess('Customer Added Successfully');
        this.getCustomers();
        // alert(res.message)
      },
      error: (error) => {
        alert(JSON.stringify(error));
        this.toaster.error('Error While Adding Customer', 'Error');
      },
    });
  }

  updateCustomer(customerObj: any) {
    this.updatedMode = true;
    this.customerForm.patchValue(customerObj);
    console.log(customerObj.value);
  }

  onUpdate() {
    this.formValue = this.customerForm.value;
    this.customerService.updateCustomerById(this.formValue).subscribe({
      next: (res) => {
        this.getCustomers();
        this.showSucess('Customer Updated Successfully');
        // alert("Updation Successful")
        this.updatedMode = false;
        this.resetForm();
      },
      error: (error) => {
        // alert("Updation Unsuccessful")
        this.toaster.error('Error While Updating Customer', 'Error');
      },
    });
  }


  // SOFT DELETE

  onDelete(customer: any){

    let isConfirm: boolean = confirm("You really want to delete?");

    if (isConfirm){

      customer.isCustomerActive = false;
      this.formValue = customer;
      
      this.customerService.updateCustomerById(this.formValue).subscribe({
        next: (res) => {
          this.showSucess('Customer Deleted Successfully');
          this.getCustomers();
        },
        error: (error) => {
          // alert("Updation Unsuccessful")
          this.toaster.error('Error While Deleting Customer', 'Error');
        },
      });
    }else{

      this.toaster.error('Deletion Unsuccessful', 'Error');
    }
  }





  // deleteCustomer(customerId: number) {
  //   this.customerService.deleteCustomerById(customerId).subscribe({
  //     next: (res) => {
  //       this.getCustomers();
  //       // alert("Deleted Successfully")
  //       this.showSucess('Customer Deleted Successfully');
  //     },
  //     error: (error) => {
  //       // alert("Deletion Unsuccessfull")
  //       this.toaster.error('Error While Deleting Customer', 'Error');
  //     },
  //   });
  // }
}
