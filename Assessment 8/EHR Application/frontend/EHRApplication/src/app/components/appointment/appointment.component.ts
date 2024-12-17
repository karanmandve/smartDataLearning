import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { UserServiceService } from '../../services/user/user-service.service';
import { PaymentService } from '../../services/razorpay-payment/payment.service';
import { AppointmentService } from '../../services/appointment/appointment.service';
import { SweetAlertToasterService } from '../../services/toaster/sweet-alert-toaster.service';
import { RouterTestingHarness } from '@angular/router/testing';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './appointment.component.html',
  styleUrl: './appointment.component.css'
})
export class AppointmentComponent {

  allSpecialisations: any[] = [];
  allProviders: any[] = [];
  fees = 0;
  userDetails: any;
  allAppointments: any[] = [];

  userService = inject(UserServiceService);
  paymentService = inject(PaymentService);
  appointmentService = inject(AppointmentService);
  toaster = inject(SweetAlertToasterService)
  router = inject(Router)


  ngOnInit() {
    this.getAllSpecialization();
    this.userService.user$.subscribe((user: any) => {
      if (user !== null){
        this.userDetails = user;
      }
    });
  }

  appointmentForm = new FormGroup({
    specialisation: new FormControl('', Validators.required),
    provider: new FormControl('', Validators.required),
    date: new FormControl('', [Validators.required]),
    time: new FormControl('', [Validators.required]),
    chiefComplaint: new FormControl('', [Validators.required, Validators.minLength(5)])
  });


  onPay() {
    this.paymentService.createOrder(this.fees).subscribe((order: any) => {
      console.log(order.id, order.amount);
      
      const options = {
        key: 'rzp_test_j1n3HfglIVc3GS',  
        amount: order.amount,
        currency: order.currency,
        order_id: order.id,
        handler: (response: any) => {
          this.bookAppointment(response.razorpay_payment_id, order.id);
          // this.verifyPayment(response.razorpay_payment_id, order.id)
        },
      };
      if (window.Razorpay) {
        const razorpay = new Razorpay(options);
        razorpay.open();
      } else {
        console.error('Razorpay SDK is not loaded properly');
      }
    });
  }


  verifyPayment(paymentId: any, orderId: any) {
    this.paymentService.verifyPayment(paymentId, orderId).subscribe({
      next: (res: any) => {
        console.log(res);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }


  async bookAppointment(paymentId: any, orderId: any) {
    console.log("hi am here");
    
    const appointmentData = this.appointmentForm.value;

    const data = {
      patientId: this.userDetails.id,
      providerId: appointmentData.provider,
      specialisationId: appointmentData.specialisation,
      appointmentDate: appointmentData.date,
      AppointmentTime: appointmentData.time,
      chiefComplaint: appointmentData.chiefComplaint,
      fee: this.fees,
      paymentId: paymentId,
      orderId: orderId
    }


    this.appointmentService.addAppointment(data).subscribe({
      next: (res: any) => {
        
        this.router.navigateByUrl('/home');
        this.toaster.success("Appointment Booked Successfully");
        console.log(res);
        setInterval(() => {
          window.location.reload();
        }, 1000);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
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




  getAllSpecialization(){
    this.userService.getSpecialization().subscribe({
      next : (res: any) => {
        this.allSpecialisations = res.data
      },
      error : (error: any) => {
        console.log(error);
      }
    })
  }

  onChange(specialisationId: any){
    this.userService.getProviderBySpecialization(specialisationId).subscribe({
      next : (res: any) => {
        this.allProviders = res.data
      },
      error : (error: any) => {
        console.log(error);
      }
    })

  }

  onChangeProvider(providerId: any){
    this.allProviders.map((provider: any) => {
      if(provider.id == providerId){
        console.log(provider.visitingCharge);
        
        this.fees = provider.visitingCharge
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
