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

  getUser(email: string){
    return this.http.get(`https://localhost:7194/api/User/getUserByEmail/${email}`)
  }

  loginUser(loginData: any){
    return this.http.post("https://localhost:7194/api/User/Auth/Authenticate", loginData)
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

  sendOtp(email: any){
    return this.http.get(`https://localhost:7194/api/User/sendotp/${email}`)
  }

}
