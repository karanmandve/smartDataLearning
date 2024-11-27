import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserServiceService } from '../../services/user/user-service.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent {

  agentEmail: any = localStorage.getItem("email")

  agentService = inject(UserServiceService)
  router = inject(Router)
  toaster = inject(ToastrService)

  newPassword: string = '';
  confirmNewPassword: string = '';
  agentDetails: any = []
  changePassworedData: any = []
  passwordRgx: RegExp = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$/
  
  
  changePasswordForm = new FormGroup({
    aId: new FormControl(0),
    oldPassword: new FormControl('', [Validators.required]),
    newPassword: new FormControl('', [Validators.required, Validators.pattern(this.passwordRgx)]),
    confirmNewPassword: new FormControl('', [Validators.required])
  })

  async getAgentDetails(){
    this.agentService.getUserDetails(this.agentEmail).subscribe({
      next: (res: any) => {
        this.agentDetails = res
        this.changePassword();
      },
      error: (error: any) => {
        alert("I am in error")
        console.log(error)
      }
    })
  }

  changePassword() {
    this.changePassworedData = this.changePasswordForm.value
    this.changePassworedData.aId = this.agentDetails.aId
    delete this.changePassworedData.confirmNewPassword
    this.agentService.changeUserPassword(this.changePassworedData).subscribe({
      next : (res: any) => {
        if(res && res.statusCode == 200){
          this.toaster.success("Password Changes Successfully", "Success")
          this.router.navigate(["/profile"])
        }else{
          this.toaster.error("Unable To Change Password", "Error")
        }
      },
      error : (error: any) => {
        if(error.error.statusCode == 400){
          this.toaster.error("Invalid Credentials", "Error")
        }else{
          alert("i am in register error")
          alert(JSON.stringify(error))
        }
      }
    
    })
    
  }


}
