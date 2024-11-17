import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserServiceService } from '../../services/user/user-service.service';

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
  passwordRgx: RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$/
  // this.loginForm.get('email').value;
  


  userService = inject(UserServiceService)
  router = inject(Router)
  toaster = inject(ToastrService)

  toggleForm() {
    this.isLogin = !this.isLogin;
  }

  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    otp: new FormControl('')
  });

  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.pattern(this.passwordRgx)]),
    confirmPassword: new FormControl('', [Validators.required]),
  })


  onLoginSubmit() {
    this.loginData = this.loginForm.value;
    delete this.loginData.otp
    this.userService.loginUser(this.loginData).subscribe({
      next: (res: any) => {
        if (res.statusCode == 200) {
          localStorage.setItem("token", res.data.token);
          localStorage.setItem("email", this.loginData.email);
          
          const expiry = new Date(res.data.expiration)
          localStorage.setItem('expiry', expiry.toISOString());
          
          this.toaster.success("Login successful", "Success",{timeOut:3000, closeButton:true});
          localStorage.setItem("session", "true")
          this.router.navigateByUrl('dashboard');
          
        } else {
          console.log(res);
          this.toaster.error("Server Error Occur", "Error",{timeOut:3000, closeButton:true});
        }
      },
      error: (error: any) => {
        if (error.error.statusCode == 401) {
          this.toaster.error("Invalid Credential", "Error",{timeOut:3000, closeButton:true});
        } else {
          alert("I am in login error");
          alert(JSON.stringify(error));
          console.log(error);
        }
      }
    });
  }

  
  onRegisterSubmit() {
    this.registerData = this.registerForm.value
    delete this.registerData.confirmPassword
    this.userService.addUser(this.registerData).subscribe({
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
    this.otpSent = true;  // Mark OTP as sent
    console.log("OTP Sent!");
    const email = this.loginForm.get('email')?.value;

    this.userService.sendOtp(email).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("Send Otp Successfully", "Success",{timeOut:3000, closeButton:true})
        }else{
          this.toaster.error("Otp Not Send", "Error",{timeOut:3000, closeButton:true})
        }
      },
      error : (error: any) => {
        if(error.error.statusCode == 409){
          this.toaster.error("Some error occur", "Error",{timeOut:3000, closeButton:true})
          this.registerForm.reset()
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }


    })
  }

  // Simulate validating OTP
  validateOtp() {
    const email = this.loginForm.get('email')?.value;
    const otp = this.loginForm.get('otp')?.value;

    const data = {
      email: email,
      otp: otp
    }

    this.userService.validateOtp(data).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("Otp Validated Successfully", "Success",{timeOut:3000, closeButton:true})
        }else{
          this.toaster.error("Otp Not Validated", "Error",{timeOut:3000, closeButton:true})
        }
      },
      error : (error: any) => {
        if(error.error.statusCode == 409){
          this.toaster.error("Some error occur", "Error",{timeOut:3000, closeButton:true})
          this.registerForm.reset()
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }

    })

  }



}
