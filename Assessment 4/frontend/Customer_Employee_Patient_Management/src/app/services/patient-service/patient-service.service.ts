import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientServiceService {

  http: HttpClient = inject(HttpClient);

  getAllPatient(){
    return this.http.get("http://localhost:5189/api/Patient");
  }

  
  addPatient(PatientObj: any): Observable<any>{
    return this.http.post("http://localhost:5189/api/Patient", PatientObj, { responseType: 'json' });
  }

  updatePatientById(PatientObj: any): Observable<any>{
    return this.http.put(`http://localhost:5189/api/Patient/${PatientObj.patientId}`, PatientObj, { responseType: 'json' })
  }

  deletePatientById(PatientId: any): Observable<any>{
    return this.http.delete(`http://localhost:5189/api/Patient/${PatientId}`)
  }

}
