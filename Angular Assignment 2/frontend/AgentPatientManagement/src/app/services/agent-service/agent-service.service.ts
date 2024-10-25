import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AgentServiceService {
  http: HttpClient = inject(HttpClient);

  getAllAgent(){
    return this.http.get("http://localhost:5258/api/Patient/allPatient");
  }

  
  addAgent(agentObj: any): Observable<any>{
    return this.http.post("http://localhost:5189/api/Patient", agentObj, { responseType: 'json' });
  }

  updateAgentById(agentObj: any): Observable<any>{
    return this.http.put(`http://localhost:5189/api/Patient/${agentObj.agentId}`, agentObj, { responseType: 'json' })
  }

  deleteAgentById(agentId: any): Observable<any>{
    return this.http.delete(`http://localhost:5189/api/Patient/${agentId}`)
  }
  
  
 
}
