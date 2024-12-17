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

  userDetails: any = null;
  newPasswordMismatch: boolean = false;
  isStateLoaded: boolean = false;
  passwordRgx: RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$/
  todayDate = new Date().toISOString().split('T')[0];
  pastDate = new Date('1900-01-01').toISOString().split('T')[0];
  fileSizeError = false;

  
  userService = inject(UserServiceService);
  toaster = inject(ToastrService);
  countryStateService: any = inject(CountryStateServiceService)
  router = inject(Router);


  ngOnInit() {
    this.userService.user$.subscribe((user: any) => {
      if (user !== null){
        this.userDetails = user;
        console.log(this.userDetails);
        
      }
    } );
  }

  onEditProfile(){
    alert("yet to implement");
  }

  onChangePassword(){
    alert("yet to implement");
  }


}
