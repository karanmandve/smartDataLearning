import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  http: HttpClient = inject(HttpClient);

  getAllCustomer(){
    return this.http.get("http://localhost:5189/api/Customer");
  }

  
  addCustomer(customerObj: any): Observable<any>{
    return this.http.post("http://localhost:5189/api/Customer", customerObj, { responseType: 'json' });
  }

  updateCustomerById(customerObj: any): Observable<any>{
    return this.http.put(`http://localhost:5189/api/Customer/${customerObj.customerId}`, customerObj, { responseType: 'json' })
  }

  deleteCustomerById(customerId: any): Observable<any>{
    return this.http.delete(`http://localhost:5189/api/Customer/${customerId}`)
  }
  
}
