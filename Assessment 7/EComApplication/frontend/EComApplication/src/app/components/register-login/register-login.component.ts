import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserServiceService } from '../../services/user/user-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoaderService } from '../../services/loader/loader.service';
import { CountryStateServiceService } from '../../services/country-state-service/country-state-service.service';
declare var bootstrap: any;

@Component({
  selector: 'app-register-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register-login.component.html',
  styleUrl: './register-login.component.css'
})
export class RegisterLoginComponent {
  isLogin: boolean = true;
  password: string = '';
  confirmPassword: string = '';
  loginData : any;
  registerData: any;
  otpSent: boolean = false;
  forgetOtpSent: boolean = false;
  passwordRgx: RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$/
  isResendDisabled: boolean = false;  // To control the resend button
  forgetOtpIsResendDisabled: boolean = false;  // To control the resend button
  forgetOtpCountdown: number = 30; // Countdown timer for resend OTP
  countdown: number = 30; // Countdown timer for resend OTP
  resendTimeout: any;
  resendOtpTimeout: any;

  @ViewChild('forgotPasswordModal') forgotPasswordModal!: ElementRef;
  
  userService = inject(UserServiceService)
  router = inject(Router)
  toaster = inject(ToastrService)
  loader = inject(LoaderService)
  countryStateService: any = inject(CountryStateServiceService)

  toggleForm() {
    this.isLogin = !this.isLogin;
  }

  ngOnInit() {
    this.getAllCountry();
  }


  loginForm: FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    otp: new FormControl('', [Validators.required])
  });

  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    mobile: new FormControl('', [Validators.required]),
    dob: new FormControl('', Validators.required),
    userTypeId: new FormControl(0, Validators.required),
    file: new FormControl<File | null>(null),
    address: new FormControl('', Validators.required),
    zipcode: new FormControl(0, [Validators.required]),
    stateId: new FormControl(0, Validators.required),
    countryId: new FormControl(0, Validators.required),
  })

  forgetPasswordForm = new FormGroup({
    username: new FormControl('', Validators.required),
    otp: new FormControl('', Validators.required),
  })

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    this.registerForm.patchValue({ file });
    this.registerForm.get('file')?.updateValueAndValidity();
  }

  openForgotPasswordModal() {
    const modal = new bootstrap.Modal(this.forgotPasswordModal.nativeElement);
    modal.show();
  }

  closeForgotPasswordModal() {
    const modalInstance = bootstrap.Modal.getInstance(this.forgotPasswordModal.nativeElement);
    modalInstance.hide();
  }


  onLoginSubmit() {
    this.loginData = this.loginForm.value;
    this.userService.loginUser(this.loginData).subscribe({
      next: (res: any) => {
        if (res.statusCode == 200) {
          localStorage.setItem("token", res.data.token);
          // localStorage.setItem("username", this.loginData.username);
          localStorage.setItem("userDetails", JSON.stringify(res.data.data));

          this.getState(res.data.data.countryId, res.data.data.stateId);


          
          const expiry = new Date(res.data.expiration)
          localStorage.setItem('expiry', expiry.toISOString());
          
          this.toaster.success("Login successful", "Success",{timeOut:3000, closeButton:true});
          localStorage.setItem("session", "true")
          this.router.navigateByUrl('home');
          
        } else {
          console.log(res);
          this.toaster.error("Server Error Occur", "Error",{timeOut:3000, closeButton:true});
        }
      },
      error: (error: any) => {
        this.loader.hide();
        if (error.error.statusCode == 401) {
          this.toaster.error("Invalid Credential", "Error",{timeOut:3000, closeButton:true});
        } else {
          console.log(error);
        }
      }
    });
  }

  
  onRegisterSubmit() {
    const formData = new FormData();
    Object.keys(this.registerForm.controls).forEach(field => {
      const value = this.registerForm.get(field)?.value;
      formData.append(field, value);
    });

    this.userService.addUser(formData).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("User Register Successfully", "Success",{timeOut:3000, closeButton:true})
          this.isLogin = true
          this.router.navigateByUrl('/')
        }else{
          this.toaster.error("User Not Register", "Error",{timeOut:3000, closeButton:true})
        }
      },
      error : (error: any) => {
        if(error.error.statusCode == 409){
          this.toaster.error("User Already Exist", "Error",{timeOut:3000, closeButton:true})
          this.registerForm.reset()
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }
    
    })
    
  }


  sendOtp() {
    // this.loader.show();
    const username = this.loginForm.get('username')?.value;
    // alert("Otp send take time 6 second. Don't click again")
    this.startResendCountdown();
    
    this.userService.sendOtp(username).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          // this.loader.hide();
          this.otpSent = true;  // Mark OTP as sent
          console.log("OTP Sent!");
          this.toaster.success("Send Otp Successfully", "Success",{timeOut:3000, closeButton:true})
        }else{
          this.toaster.error("Otp Not Send", "Error",{timeOut:3000, closeButton:true})
        }
      },
      error : (error: any) => {
        this.loader.hide();
        if(error.error.statusCode == 401){
          this.toaster.error("Invalid Credential, Otp Not Send", "Error",{timeOut:3000, closeButton:true})
          this.registerForm.reset()
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }
    })
  }

sendForgetOtp() {
  // this.loader.show();
  const username = this.forgetPasswordForm.get('username')?.value;
  // alert("Otp send take time 6 second. Don't click again")
  this.startForgetOtpResendCountdown();
  
  this.userService.sendOtp(username).subscribe({
    next : (res: any) => {
      if(res.statusCode == 200){
        // this.loader.hide();
        this.forgetOtpSent = true;  // Mark OTP as sent
        console.log("OTP Sent!");
        this.toaster.success("Send Otp Successfully", "Success",{timeOut:3000, closeButton:true})
      }else{
        this.toaster.error("Otp Not Send", "Error",{timeOut:3000, closeButton:true})
      }
    },
    error : (error: any) => {
      this.loader.hide();
      if(error.error.statusCode == 401){
        this.toaster.error("Invalid Credential, Otp Not Send", "Error",{timeOut:3000, closeButton:true})
        this.registerForm.reset()
      }else{
        alert("i am in register error")
        alert(JSON.stringify(error))
      }
    }
  })
}

  resetPassword() {
    const username = this.forgetPasswordForm.get('username')?.value;
    const otp = this.forgetPasswordForm.get('otp')?.value;

    this.userService.verifyOtp(username, otp).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("New Password Send To Your Registered Email", "Success",{timeOut:3000, closeButton:true})
          this.closeForgotPasswordModal();
        }else{
          this.toaster.error("Password Not Send", "Error",{timeOut:3000, closeButton:true})
        }
      },
      error : (error: any) => {
        this.loader.hide();
        if(error.error.statusCode == 401){
          this.toaster.error("Invalid Credential, Password Not Send", "Error",{timeOut:3000, closeButton:true})
          this.registerForm.reset()
        }else{
          alert(JSON.stringify(error))
      }
  }})
  }

    // Start countdown for resend OTP button
    startResendCountdown() {
      this.isResendDisabled = true;  // Disable the resend button
      this.countdown = 30;  // Set initial countdown time
      this.resendTimeout = setInterval(() => {
        this.countdown--;  // Decrease the countdown by 1 each second
        if (this.countdown <= 0) {
          clearInterval(this.resendTimeout);  // Stop the countdown when it reaches 0
          this.isResendDisabled = false;  // Enable the resend button again
        }
      }, 1000);  // Run every second
    }

    startForgetOtpResendCountdown() {
      this.forgetOtpIsResendDisabled = true;  // Disable the resend button
      this.forgetOtpCountdown = 30;  // Set initial countdown time
      this.resendOtpTimeout = setInterval(() => {
        this.forgetOtpCountdown--;  // Decrease the countdown by 1 each second
        if (this.forgetOtpCountdown <= 0) {
          clearInterval(this.resendOtpTimeout);  // Stop the countdown when it reaches 0
          this.forgetOtpIsResendDisabled = false;  // Enable the resend button again
        }
      }, 1000);  // Run every second
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
  
    getState(countrId : any, stateId: any){
      this.countryStateService.getStateByCountryId(countrId).subscribe({
        next : (res:any) => {
          this.allState = res
          const state = this.allState.find(s => s.stateId === stateId);
          localStorage.setItem("stateName", state.name)

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
