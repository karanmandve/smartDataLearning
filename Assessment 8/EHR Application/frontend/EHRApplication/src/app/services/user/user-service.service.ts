import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  
  private userSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public user$: Observable<any> = this.userSubject.asObservable();


  http = inject(HttpClient);



  fetchUserData(username: any): Observable<any> {
    return this.http.get(`https://localhost:7228/api/User/get-user-details/${username}`)
  }

  updateUserDetails(username: any) {
    this.fetchUserData(username).subscribe({
      next: (res: any) => {
        this.setUserData(res.data);
      }
    })
  }

  setUserData(user: any) {
    this.userSubject.next(user);
  }

  getUserData() {
    return this.userSubject.value;
  }



  addUser(userObj: any): Observable<any>{
    return this.http.post("https://localhost:7228/api/User/register", userObj)
  }

  loginUser(loginData: any){
    return this.http.post("https://localhost:7228/api/User/Login", loginData)
  }
  
  sendOtp(username: any){
    return this.http.get(`https://localhost:7228/api/User/sendotp/${username}`)
  }

  forgotPassword(username: any, otp: any){
    return this.http.get(`https://localhost:7228/api/User/forgot-password/${username}/${otp}`)
  }

  getSpecialization(){
    return this.http.get("https://localhost:7228/get-all-specialisation")
  }

  getProviderBySpecialization(specialisationId: any){
    return this.http.get(`https://localhost:7228/api/User/get-all-provider-by-specialisationId/${specialisationId}`)
  }
  
  updateUser(userObj: any): Observable<any>{
    return this.http.put("https://localhost:7228/api/User/update-user", userObj)
  }
  
  getUser(email: string){
    return this.http.get(`https://localhost:7194/api/User/getUserByEmail/${email}`)
  }

  getAllUser(){
    return this.http.get("https://localhost:7194/api/User/GetAllUsers")
  }


  // updateUserById(UserObj: any): Observable<any>{
  //   return this.http.put(`https://localhost:7194/api/User/${UserObj.userId}`, UserObj, { responseType: 'json' })
  // }


  deletePatientById(UserId: any): Observable<any>{
    return this.http.delete(`https://localhost:7194/api/User/${UserId}`)
  }

  changePassword(data: any): Observable<any>{
    return this.http.post("https://localhost:7238/api/User/change-password", data);
  }


}
