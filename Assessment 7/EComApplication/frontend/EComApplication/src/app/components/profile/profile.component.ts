import { Component, inject, OnInit } from '@angular/core';
import { UserServiceService } from '../../services/user/user-service.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule, DatePipe, TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, TitleCasePipe, DatePipe],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  userAllData: any;
  email: string = localStorage.getItem('email') || '';

  userService = inject(UserServiceService);
  toaster = inject(ToastrService);

  ngOnInit(): void {

    this.userService.getUser(this.email).subscribe({
      next: (res: any) => {
        console.log(res)
        this.userAllData = res;
      },
      error: (err: any) => {
        this.toaster.error(
          'An error occurred while fetching user details. Please try again later.',
          'Error'
        );
      },
    });

  }
}
