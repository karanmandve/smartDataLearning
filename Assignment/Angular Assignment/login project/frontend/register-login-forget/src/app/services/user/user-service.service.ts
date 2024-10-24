import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  http = inject(HttpClient);


  addUser(userObj: any): Observable<any>{
    return this.http.post("http://localhost:5258/api/User", userObj)
  }

  getUser(email: string){
    return this.http.get(`http://localhost:5258/api/User/get-user-by-email/${email}`)
  }

  loginUser(loginData: any){
    return this.http.post("http://localhost:5258/login-user", loginData)
  }


}
