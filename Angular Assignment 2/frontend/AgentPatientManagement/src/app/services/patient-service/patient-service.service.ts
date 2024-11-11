import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientServiceService {
  http: HttpClient = inject(HttpClient);

  getAllPatient(agentId: any): Observable<any>{
    return this.http.get(`http://localhost:5258/api/Patient/activePatientByAgentId/${agentId}`);
  }

  
  addPatient(PatientObj: any): Observable<any>{
    return this.http.post("http://localhost:5258/api/Patient", PatientObj, { responseType: 'json' });
  }

  updatePatientById(PatientObj: any): Observable<any>{
    return this.http.put(`http://localhost:5258/api/Patient/${PatientObj.pId}`, PatientObj, { responseType: 'json' })
  }

  deletePatientById(PatientId: any): Observable<any>{
    return this.http.delete(`http://localhost:5258/api/Patient/${PatientId}`)
  }
  
  
 
}
