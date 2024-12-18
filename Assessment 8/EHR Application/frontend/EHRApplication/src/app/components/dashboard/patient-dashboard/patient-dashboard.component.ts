import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserServiceService } from '../../../services/user/user-service.service';
import { AppointmentService } from '../../../services/appointment/appointment.service';
import { CommonModule } from '@angular/common';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { SweetAlertToasterService } from '../../../services/toaster/sweet-alert-toaster.service';
import Swal from 'sweetalert2';
declare var bootstrap: any;
@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.css'
})
export class PatientDashboardComponent {

  allAppointments: any[] = [];
  filterAppointments: any[] = [];
  userDetails: any;


  appointmentService = inject(AppointmentService);
  userService = inject(UserServiceService);
  toaster  = inject(SweetAlertToasterService);


  ngOnInit() {
    this.userService.user$.subscribe((user: any) => {
      if (user !== null){
        this.userDetails = user;
        this.getAllAppointments();
      }
    });
  }

  appointmentForm = new FormGroup({
    id : new FormControl(''),
    appointmentDate : new FormControl(''),
    appointmentTime : new FormControl(''),
    chiefComplaint : new FormControl(''),
});



  getAllAppointments() {
    this.appointmentService.getAppointmentsByPatientId(this.userDetails.id).subscribe({
      next: (res: any) => {
        this.allAppointments = res.data
        this.filterAppointments = this.allAppointments.filter((appointment: any) => appointment.appointmentStatus === "Scheduled");
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  openModal(): void {
    const modalElement = document.getElementById('appointmentModal') as HTMLElement;
    const modal = new bootstrap.Modal(modalElement); 
    modal.show(); 
  }

  closeModal(): void {
    const modalElement = document.getElementById('appointmentModal') as HTMLElement;
    const modal = bootstrap.Modal.getInstance(modalElement); 
    modal.hide(); 
  }

  onEditAppointment(appointment: any) {
    this.openModal();
    this.appointmentForm.patchValue(appointment);
  }


  confirmDeletion(appointment: any): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this item!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, cancel it!',
      cancelButtonText: 'No!',
    }).then((result) => {
      if (result.isConfirmed) {
        // Perform the delete operation
        this.onCancelAppointment(appointment);
        
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        // Swal.fire('Cancelled', 'Your item is safe.', 'info');
      }
    });
  }
  
  onCancelAppointment(appointment: any) {
    this.appointmentService.cancelAppointment(appointment.id).subscribe({
      next: (res: any) => {
        this.getAllAppointments();
        this.toaster.success('Appointment cancelled successfully');
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  onSubmit() {

    this.appointmentService.updateAppointment(this.appointmentForm.value).subscribe({
      next: (res: any) => {
        this.closeModal();
        this.getAllAppointments();
        this.toaster.success('Appointment updated successfully');
      },
      error: (error: any) => {
        this.toaster.success('Server Error');
        console.log(error);
      }
    })
  }




}
