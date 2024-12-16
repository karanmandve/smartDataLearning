import { CommonModule, DatePipe } from '@angular/common';
import { Component, Inject, inject } from '@angular/core';
import { UserServiceService } from '../../services/user/user-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CountryStateServiceService } from '../../services/country-state-service/country-state-service.service';
import { Router } from '@angular/router';
declare var bootstrap: any;

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [DatePipe, ReactiveFormsModule, CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  profileData: any;
  newPasswordMismatch: boolean = false;
  isStateLoaded: boolean = false;
  passwordRgx: RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$/
  userDetails = JSON.parse(localStorage.getItem("userDetails") || '{}');
  todayDate = new Date().toISOString().split('T')[0];
  pastDate = new Date('1900-01-01').toISOString().split('T')[0];
  fileSizeError = false;
  
  userService = inject(UserServiceService);
  toaster = inject(ToastrService);
  countryStateService: any = inject(CountryStateServiceService)
  router = inject(Router);
  

    ngOnInit(): void {  
      this.getAllCountry();
      this.getState(this.userDetails.stateId);
      this.sanitizeField('firstName');
      this.sanitizeField('lastName');

      this.changePasswordForm.valueChanges.subscribe(() => {
        const newPassword = this.changePasswordForm.get('newPassword')?.value;
        const confirmPassword = this.changePasswordForm.get('confirmNewPassword')?.value;
        this.newPasswordMismatch = newPassword !== confirmPassword;
        
      });
    }
  
  changePasswordForm = new FormGroup({
    newPassword: new FormControl('', [Validators.required, Validators.pattern(this.passwordRgx)]),
    confirmNewPassword: new FormControl('', [Validators.required])
  });


  userForm = new FormGroup({
    id: new FormControl('', [Validators.required]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(20),Validators.pattern(/^[A-Za-z]+(?: [A-Za-z]+)*\s*$/)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(25),Validators.pattern(/^[A-Za-z]+(?: [A-Za-z]+)*\s*$/)]),
    mobile: new FormControl('', [Validators.required, Validators.pattern(/^\d{10}$/)]),
    dob: new FormControl('', [Validators.required, this.futureDateValidator]),
    address: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(150), Validators.pattern(/^[a-zA-Z0-9\s,.-]+$/)]),
    zipcode: new FormControl('', [Validators.required, Validators.pattern(/^\d{6}$/), Validators.minLength(6), Validators.maxLength(6)]),
    stateId: new FormControl('', [Validators.required]),
    countryId: new FormControl('', [Validators.required]),
    imageFile: new FormControl<File | null>(null)
  });


  futureDateValidator(control: FormControl): ValidationErrors | null {
    const today = new Date();
    const pastDate = new Date('1900-01-01');
    const selectedDate = new Date(control.value);

    // Reset time to the start of the day (to avoid time comparisons)
    // today.setHours(0, 0, 0, 0);

    if (selectedDate > today) {
      return { futureDate: true };  // Return error if date is in the future
    }else if(selectedDate < pastDate){
      return { pastDate: true };
      }  // Return error if date is in the future
    return null;  // Return null if date is valid
  }




  get f() {
    return this.userForm.controls;
  }

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    const maxSize = 5 * 1024 * 1024;

    if (file) {
      const validTypes = ['image/jpeg', 'image/jpg', 'image/png'];
      if (!validTypes.includes(file.type)) {
        // Set the custom error for invalid file type
        this.userForm.get('imageFile')?.setErrors({ invalidType: true });
        if (event.target instanceof HTMLInputElement) {
          event.target.value = '';
        }
      } else {
        // Clear the error if the file type is valid
        this.userForm.get('imageFile')?.setErrors(null);
      }
    }
    if (file) {
      // Check if the file size exceeds the 5 MB limit
      if (file.size > maxSize) {
        this.fileSizeError = true;
        // Clear the file input if it exceeds the limit
        if (event.target instanceof HTMLInputElement) {
          event.target.value = '';
        }
      } else {
        this.fileSizeError = false;
      }
    }
    this.userForm.patchValue({ imageFile: file });
    this.userForm.get('imageFile')?.updateValueAndValidity();
  }

  sanitizeField(fieldName: string): void {
    this.userForm.get(fieldName)?.valueChanges.subscribe((value) => {
      if (value) {
        
        const sanitizedValue = value
          .replace(/[^A-Za-z\s]/g, '') 
          .replace(/\s{2,}/g, ' '); 
        if (value !== sanitizedValue) {
          this.userForm.get(fieldName)?.setValue(sanitizedValue, {
            emitEvent: false, 
          });
        }
      }
    });
  }

  onKeyPress(event: KeyboardEvent) {
    const charCode = event.which ? event.which : event.keyCode;

    if (charCode < 48 || charCode > 57) {
      event.preventDefault(); 
    }
  }


  onSubmit(): void {


    const formData = new FormData();
    Object.keys(this.userForm.controls).forEach(field => {
      const value = this.userForm.get(field)?.value;
      formData.append(field, value);
    });

    this.userService.updateUser(formData).subscribe({
      next: (res: any) => {
        window.location.reload();
        if (res.statusCode === 200) {
          this.toaster.success("Profile updated successfully", "Success", { timeOut: 3000, closeButton: true });
          this.closeModal();
          this.userDetails = res.data;
          localStorage.removeItem('userDetails');
          localStorage.setItem('userDetails', JSON.stringify(res.data));
        } else {
          this.toaster.error("Error while updating profile", "Error", { timeOut: 3000, closeButton: true });
        }
      },
      error: (err: any) => {
        window.location.reload();
        this.toaster.error("An error occurred", "Error", { timeOut: 3000, closeButton: true });
      }
    });
  }

  // Modal open handler
  editProfile(): void {
    const myModal = new bootstrap.Modal(document.getElementById('editProfileModal'));
    myModal.show();
    this.userForm.patchValue(this.userDetails);
    this.getState(this.userDetails.countryId);
    
  }

  closeModal(): void {
    const modal = bootstrap.Modal.getInstance(document.getElementById('editProfileModal') as Element);
    modal.hide();
    this.userForm.reset();
  }


  openChangePasswordModal(): void {
    const modal = new bootstrap.Modal(document.getElementById('changePasswordModal') as Element);
    modal.show();
  }

  closeChangePasswordModal(): void {
    const modal = bootstrap.Modal.getInstance(document.getElementById('changePasswordModal') as Element);
    modal.hide();
  }

  changePassword(): void {
    this.openChangePasswordModal();
  }

  onChangePasswordSubmit(): void {
    const newPassword = this.changePasswordForm.get('newPassword')?.value;
    const username = this.userDetails.username;

    const changePasswordData = {
      username: username,
      newPassword: newPassword
    }

    this.userService.changePassword(changePasswordData).subscribe({
      next: (res: any) => {
        if (res.statusCode === 200) {
          this.toaster.success("Password changed successfully", "Success", { timeOut: 3000, closeButton: true });
          this.closeChangePasswordModal();
        } else {
          this.toaster.error("Error while changing password", "Error", { timeOut: 3000, closeButton: true });
        }
      },
      error: (err: any) => {
        this.toaster.error("An error occurred", "Error", { timeOut: 3000, closeButton: true });
      }
    });
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
        console.log(this.allState);
        this.isStateLoaded = true;
        
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
