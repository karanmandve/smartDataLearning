import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  http = inject(HttpClient);


  addUser(userObj: any): Observable<any>{
    return this.http.post("https://localhost:7238/api/User/register", userObj)
  }

  loginUser(loginData: any){
    return this.http.post("https://localhost:7238/api/User/Login", loginData)
  }
  
  sendOtp(username: any){
    return this.http.get(`https://localhost:7238/api/User/sendotp/${username}`)
  }

  verifyOtp(username: any, otp: any){
    return this.http.get(`https://localhost:7238/api/User/forget-password/${username}/${otp}`)
  }

  getUser(email: string){
    return this.http.get(`https://localhost:7194/api/User/getUserByEmail/${email}`)
  }

  getAllUser(){
    return this.http.get("https://localhost:7194/api/User/GetAllUsers")
  }


  updateUserById(UserObj: any): Observable<any>{
    return this.http.put(`https://localhost:7194/api/User/${UserObj.userId}`, UserObj, { responseType: 'json' })
  }

  deletePatientById(UserId: any): Observable<any>{
    return this.http.delete(`https://localhost:7194/api/User/${UserId}`)
  }

  // changePassword(data: any): Observable<any>{
  //   return this.http.post("http://localhost:5258/change-password", data);
  // }


}
