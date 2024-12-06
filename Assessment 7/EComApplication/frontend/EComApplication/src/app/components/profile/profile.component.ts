import { CommonModule, DatePipe } from '@angular/common';
import { Component, Inject, inject } from '@angular/core';
import { UserServiceService } from '../../services/user/user-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
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
  userDetails = JSON.parse(localStorage.getItem("userDetails") || '{}');
  
  userService = inject(UserServiceService);
  toaster = inject(ToastrService);
  countryStateService: any = inject(CountryStateServiceService)
  router = inject(Router);
  

    ngOnInit(): void {  
      this.getAllCountry();
      this.getState(this.userDetails.stateId);

      this.changePasswordForm.valueChanges.subscribe(() => {
        const newPassword = this.changePasswordForm.get('newPassword')?.value;
        const confirmPassword = this.changePasswordForm.get('confirmNewPassword')?.value;
        this.newPasswordMismatch = newPassword !== confirmPassword;
      });
    }
  
  changePasswordForm = new FormGroup({
    newPassword: new FormControl('', [Validators.required]),
    confirmNewPassword: new FormControl('', [Validators.required])
  });


  userForm = new FormGroup({
    id: new FormControl('', [Validators.required]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    mobile: new FormControl('', [
      Validators.required,
    ]),
    dob: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    zipcode: new FormControl('', [Validators.required]),
    stateId: new FormControl('', [Validators.required]),
    countryId: new FormControl('', [Validators.required]),
    imageFile: new FormControl<File | null>(null)
  });

  get f() {
    return this.userForm.controls;
  }

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    this.userForm.patchValue({ imageFile : file });
    this.userForm.get('imageFile')?.updateValueAndValidity();
  }


  onSubmit(): void {


    const formData = new FormData();
    Object.keys(this.userForm.controls).forEach(field => {
      const value = this.userForm.get(field)?.value;
      formData.append(field, value);
    });

    this.userService.updateUser(formData).subscribe({
      next: (res: any) => {
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
