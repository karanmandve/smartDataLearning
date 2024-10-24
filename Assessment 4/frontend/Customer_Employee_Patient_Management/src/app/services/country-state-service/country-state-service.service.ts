import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryStateServiceService {

  http = inject(HttpClient)


  getAllCountry(){
    return this.http.get("http://localhost:5189/api/Country");
  }

  getStateByCountryId(countryId: number){
    return this.http.get(`http://localhost:5189/api/State/${countryId}`);
  }

  getAllState(){
    return this.http.get("http://localhost:5189/all-state");
  }


}
