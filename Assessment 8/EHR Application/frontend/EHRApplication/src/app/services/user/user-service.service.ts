import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';
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

  sendOtpWithPasswordCheck(userData: any){
    return this.http.post(`https://localhost:7228/api/User/sendotp-with-password-check`, userData)
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
  
  getAllPatient(){
    return this.http.get("https://localhost:7228/api/User/get-all-patient");
  }
  
  updatePatient(patientData: any){
    return this.http.put("https://localhost:7228/api/User/update-patient", patientData)
  }

  updateProvider(providerData: any){
    return this.http.put("https://localhost:7228/api/User/update-provider", providerData)
  }

  updateUser(userObj: any): Observable<any>{
    return this.http.put("https://localhost:7228/api/User/update-user", userObj)
  }

  changePassword(data: any){
    return this.http.post("https://localhost:7228/api/User/change-password", data)
  }


  
  // getUser(email: string){
  //   return this.http.get(`https://localhost:7194/api/User/getUserByEmail/${email}`)
  // }

  // getAllUser(){
  //   return this.http.get("https://localhost:7194/api/User/GetAllUsers")
  // }


  // updateUserById(UserObj: any): Observable<any>{
  //   return this.http.put(`https://localhost:7194/api/User/${UserObj.userId}`, UserObj, { responseType: 'json' })
  // }


  // deletePatientById(UserId: any): Observable<any>{
  //   return this.http.delete(`https://localhost:7194/api/User/${UserId}`)
  // }

  // changePassword(data: any): Observable<any>{
  //   return this.http.post("https://localhost:7238/api/User/change-password", data);
  // }


}
