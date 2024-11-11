import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserServiceService } from '../../services/user/user-service.service';
import { UtilsService } from '../../services/utils/session';

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
  loginData : any;
  registerData: any;
  confirmPassword: string = '';
  


  userService = inject(UserServiceService)
  session = inject(UtilsService)
  router = inject(Router)
  toaster = inject(ToastrService)

  toggleForm() {
    this.isLogin = !this.isLogin;
  }

  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    confirmPassword: new FormControl('', [Validators.required]),
  })


  // registerForm.get('confirmPassword')?.valueChanges.subscribe(() => {
  //   this.registerForm.updateValueAndValidity();
  // });


  onLoginSubmit() {
    this.loginData = this.loginForm.value
    this.userService.loginUser(this.loginData).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("login successful", "success")
          this.router.navigate(["/profile"])
          this.session.setSession(true)
          localStorage.setItem("email", `${this.loginData.email}`);
          localStorage.setItem("session", "true")
        }else{
          this.toaster.error("Server Error Occur", "Error")
        }
      },
      error : (error: any) => {
        if (error.error.statusCode == 401){
          this.toaster.error("Invalid Credential", "Error")

        }else{

          alert("i am in login error")
          alert(JSON.stringify(error))
          console.log(error)
        }
      }
    })
  }
  
  onRegisterSubmit() {
    this.registerData = this.registerForm.value
    delete this.registerData.confirmPassword
    this.userService.addUser(this.registerData).subscribe({
      next : (res: any) => {
        if(res.statusCode == 200){
          this.toaster.success("user register successfully", "success")
          this.isLogin = true
          this.router.navigate([""])
        }else{
          this.toaster.error("User Not Register", "Error")
        }
      },
      error : (error: any) => {
        if(error.error.statusCode == 409){
          this.toaster.error("User Already Exist", "Error")
          this.registerForm.reset()
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }
    
    })
    
  }



}
