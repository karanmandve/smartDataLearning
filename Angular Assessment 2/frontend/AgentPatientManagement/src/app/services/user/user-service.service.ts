import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  http = inject(HttpClient);


  addUser(userObj: any): Observable<any>{
    return this.http.post("http://localhost:5258/api/Agent", userObj)
  }
  
  getUserDetails(email: any){
    return this.http.get(`http://localhost:5258/api/Agent/get-agent-by-email/${email}`)
  }

  loginUser(loginData: any){
    return this.http.post("http://localhost:5258/login-agent", loginData)
  }

  changeUserPassword(changePasswordData: any){
    return this.http.post("http://localhost:5258/change-password", changePasswordData)
  }


}
