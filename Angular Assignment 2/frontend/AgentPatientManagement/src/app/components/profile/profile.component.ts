import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UtilsService } from '../../services/utils/session';
import { ToastrService } from 'ngx-toastr';
import { AgentServiceService } from '../../services/agent-service/agent-service.service';
import { CountryStateServiceService } from '../../services/country-state-service/country-state-service.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  AgentEmail = localStorage.getItem("email")

  session = inject(UtilsService)
  router = inject(Router)
  toaster = inject(ToastrService)

  logout(){
    localStorage.clear()
    this.session.setSession(false)
    this.router.navigate(["/"])
    this.toaster.success("Logout Successfull", "Success")
  }


  customerService = inject(AgentServiceService);
  countryStateService: any = inject(CountryStateServiceService)
  allCustomer: any[] = [];

  /**
   *
   */
  constructor() {
    this.getCustomers();
  }
  
  ngOnInit(): void {
    this.getCustomers();
    this.getAllCountry();
    this.loadState();
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
    state: new FormControl(0),
    country: new FormControl(0),
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
      state: 0,
      country: 0,
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
  }

  onUpdate() {
    this.formValue = this.customerForm.value;
    this.customerService.updateCustomerById(this.formValue).subscribe({
      next: (res) => {
        this.showSucess('Customer Updated Successfully');
        // alert("Updation Successful")
        this.updatedMode = false;
        this.resetForm();
        this.getCustomers();
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
        next: (res: any) => {
          this.showSucess('Customer Deleted Successfully');
          this.getCustomers();
        },
        error: (error: any) => {
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


  loadState(){
    this.countryStateService.getAllState().subscribe({
      next : (res:any) => {
        this.allState = res
      },
      error : (error: any) => {
        alert("I am in error")
      }
    })
  }

  onChange(countrId : any){
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
