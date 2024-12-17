import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserServiceService } from '../../../services/user/user-service.service';
import { AppointmentService } from '../../../services/appointment/appointment.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.css'
})
export class PatientDashboardComponent {

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
    this.appointmentService.getAppointmentsByPatientId(this.userDetails.id).subscribe({
      next: (res: any) => {
        this.allAppointments = res.data
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }



  onEditAppointment(appointment: any) {
    alert("yet to implement");
  }
  
  onCancelAppointment(appointment: any) {
    alert("yet to implement");
  }




}
