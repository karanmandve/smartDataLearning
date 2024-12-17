import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  http = inject(HttpClient)



  addAppointment(appointmentObj: any){
    return this.http.post("https://localhost:7228/api/Appointment/add-appointment", appointmentObj)
  }



}
