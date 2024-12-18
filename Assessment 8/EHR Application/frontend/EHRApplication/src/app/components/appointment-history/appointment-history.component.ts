import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { UserServiceService } from '../../services/user/user-service.service';
import { AppointmentService } from '../../services/appointment/appointment.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-appointment-history',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './appointment-history.component.html',
  styleUrl: './appointment-history.component.css'
})
export class AppointmentHistoryComponent {

  allAppointments: any[] = [];
  filterAppointments: any[] = [];
  userDetails: any;

  userService = inject(UserServiceService);
  appointmentService = inject(AppointmentService);


  ngOnInit() {
    this.userService.user$.subscribe((user: any) => {
      if (user !== null){
        this.userDetails = user;
        this.getAllAppointments();
      }
    });
  }


  appointmentStatusform = new FormGroup({
    appointmentStatus: new FormControl(''),
  });
  
  appointmentStatusFiltered(appointmentStatus: any){
  
    if (appointmentStatus === '') {
      this.filterAppointments = this.allAppointments.filter((appointment: any) => appointment.appointmentStatus === "Cancelled" || appointment.appointmentStatus === "Completed");
    } else {
      this.filterAppointments = this.allAppointments.filter((appointment: any) => appointment.appointmentStatus === appointmentStatus);
    }
  }

  getAllAppointments() {
    this.appointmentService.getAppointmentsByPatientId(this.userDetails.id).subscribe({
      next: (res: any) => {
        this.allAppointments = res.data
        this.filterAppointments = this.allAppointments.filter((appointment: any) => appointment.appointmentStatus === "Cancelled" || appointment.appointmentStatus === "Completed");
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

}
