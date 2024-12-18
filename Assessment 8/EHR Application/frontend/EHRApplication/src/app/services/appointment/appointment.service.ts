import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  http = inject(HttpClient)

  private cancelPendingRequests$ = new Subject<void>()
  public cancelPendingRequests() {
    this.cancelPendingRequests$.next()
  }

  public onCancelPendingRequests() {
    return this.cancelPendingRequests$.asObservable()
  }



  addAppointment(appointmentObj: any){
    return this.http.post("https://localhost:7228/api/Appointment/add-appointment", appointmentObj)
  }

  getAppointmentsByPatientId(patientId: string){
    return this.http.get(`https://localhost:7228/api/Appointment/get-appointment-by-patient/${patientId}`)
  }

  getAppointmentsByProviderId(providerId: string){
    return this.http.get(`https://localhost:7228/api/Appointment/get-appointment-by-provider/${providerId}`)
  }

  updateAppointment(data:any){
    return this.http.put("https://localhost:7228/api/Appointment/update-appointment", data)
  }

  cancelAppointment(appointmentId: any){
    return this.http.delete(`https://localhost:7228/api/Appointment/cancel-appointment/${appointmentId}`)
  }
  
  addSoapNotes(data: any){
    return this.http.post("https://localhost:7228/api/SoapNote/add-soapnote", data)
  }



}
