import { Component, inject } from '@angular/core';
import { AppointmentService } from '../../../services/appointment/appointment.service';
import { UserServiceService } from '../../../services/user/user-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-provider-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './provider-dashboard.component.html',
  styleUrl: './provider-dashboard.component.css'
})
export class ProviderDashboardComponent {

  allAppointments: any[] = [];
  userDetails: any;


  appointmentService = inject(AppointmentService);
  userService = inject(UserServiceService);


  ngOnInit() {
    this.userService.user$.subscribe((user: any) => {
      if (user !== null){
        this.userDetails = user;
        this.getAllAppointments();
      }
    });
  }


  getAllAppointments() {
    this.appointmentService.getAppointmentsByProviderId(this.userDetails.id).subscribe({
      next: (res: any) => {
        this.allAppointments = res.data
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  
  onCancelAppointment(appointment: any) {
    alert("yet to implement");
  }
}
