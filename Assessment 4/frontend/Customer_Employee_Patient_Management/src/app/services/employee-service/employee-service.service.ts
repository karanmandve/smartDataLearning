import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  
  http: HttpClient = inject(HttpClient);

  getAllEmployee(){
    return this.http.get("http://localhost:5189/api/Employee");
  }

  
  addEmployee(employeeObj: any): Observable<any>{
    return this.http.post("http://localhost:5189/api/Employee", employeeObj, { responseType: 'json' });
  }

  updateEmployeeById(employeeObj: any): Observable<any>{
    return this.http.put(`http://localhost:5189/api/Employee/${employeeObj.employeeId}`, employeeObj, { responseType: 'json' })
  }

  deleteEmployeeById(employeeId: any): Observable<any>{
    return this.http.delete(`http://localhost:5189/api/Employee/${employeeId}`)
  }



}
