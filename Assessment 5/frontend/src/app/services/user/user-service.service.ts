import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  http = inject(HttpClient);


  addUser(userObj: any): Observable<any>{
    return this.http.post("https://localhost:7194/api/User/register", userObj)
  }

  // getUser(email: string){
  //   return this.http.get(`http://localhost:5258/api/Agent/get-agent-by-email/${email}`)
  // }

  loginUser(loginData: any){
    return this.http.post("https://localhost:7194/api/User/login", loginData)
  }

  // changePassword(data: any): Observable<any>{
  //   return this.http.post("http://localhost:5258/change-password", data);
  // }

  sendOtp(email: any){
    return this.http.get(`https://localhost:7194/api/User/sendotp/${email}`)
  }

  validateOtp(data: any){
    return this.http.post("https://localhost:7194/api/User/verifyOtp", data)
  }
}
