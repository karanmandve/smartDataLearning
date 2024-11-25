import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterEvent, RouterLink, RouterOutlet } from '@angular/router';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { CommonModule, JsonPipe, TitleCasePipe } from '@angular/common';
import { NavbarComponent } from "../navbar/navbar.component";
import { UserServiceService } from '../../services/user/user-service.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [TitleCasePipe, NavbarComponent, CommonModule, ReactiveFormsModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  router = inject(Router);
  toaster = inject(ToastrService);
  email: string = localStorage.getItem('email') || '';
  userAllData: any;
  allUserData: any[] = [];
  formValue: any;
  isUpdateMode:any = false;
  isAdmin: boolean = false;
  
  userService = inject(UserServiceService);
  
  ngOnInit(): void {
    this.checkTokenExpiry();
    this.userService.getUser(this.email).subscribe({
      next: (res: any) => {
        this.userAllData = res;
        console.log(this.userAllData)
        this.isAdmin = this.userAllData.role === 'Admin' ? true : false;
      },
      error: (err: any) => {
        this.toaster.error(
          'An error occurred while fetching user details. Please try again later.',
          'Error'
        );
      },
    });

    this.getAllUsers();
  }

  checkTokenExpiry() {
    const expiryTime = localStorage.getItem('expiry');

    if (expiryTime) {
      const expireIn = new Date(expiryTime);
      const currentTime = new Date();

      if (currentTime >= expireIn) {
        this.logout('auto');
      } else {
        const timeRemaining = expireIn.getTime() - currentTime.getTime();
        setTimeout(() => {
          this.logout('auto');
        }, timeRemaining);
      }
    } else {
      this.logout('auto');
    }
  }


  getAllUsers(){
    this.userService.getAllUser().subscribe({
      next: (res: any) => {
        this.allUserData = res;
        console.log(this.allUserData)
        console.log(this.allUserData[0].firstName)
      },
      error: (err: any) => {
        this.toaster.error(
          'An error occurred while fetching user details. Please try again later.',
          'Error'
        );
      },
    });
  }

  logout(type: 'manual' | 'auto') {
    localStorage.clear();
    this.router.navigate(['/']);

    if (type === 'auto') {
      this.toaster.info(
        'Your session has expired. You have been logged out automatically.',
        'Session Expired'
      );
    } else if (type === 'manual') {
      this.toaster.success(
        'You have successfully logged out.',
        'Logout Successful'
      );
    }
  }



  userForm: FormGroup = new FormGroup({
    userId: new FormControl(0),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    role: new FormControl('', [Validators.required])
  });

  resetForm() {
    this.userForm.reset({
      firstName: '',
      lastName: '',
      email: '',
      role: ''
    });
  }



  updateUser(UserObj: any) {
    console.log(UserObj);
    this.isUpdateMode = true;
    this.userForm.patchValue(UserObj);
  }

  onUpdate() {
    this.formValue = this.userForm.value;

    this.userService.updateUserById(this.formValue).subscribe({
      next: (res: any) => {
        // alert("Updation Successful")
        this.isUpdateMode = false;
        this.resetForm();
        this.getAllUsers();
        this.toaster.success('User Updated Successfully', 'Success');
      },
      error: (error: any) => {
        alert(JSON.stringify(error))
        this.toaster.error('Error While Updating User', 'Error');
      },
    });
  }







  deleteUser(UserId: number) {
    this.userService.deletePatientById(UserId).subscribe({
      next: (res: any) => {
        this.toaster.success('User Deleted Successfully', 'Success');
        this.getAllUsers()
      },
      error: (error: any) => {
        // alert("Deletion Unsuccessfull")
        this.toaster.error('Error While Deleting User', 'Error');
      },
    });
  }










}
