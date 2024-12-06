import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryStateServiceService {

  http = inject(HttpClient)


  getAllCountry(){
    return this.http.get("https://localhost:7238/api/Country");
  }

  getStateByCountryId(countryId: number){
    return this.http.get(`https://localhost:7238/api/State/state-by-countryId/${countryId}`);
  }

  getAllState(){
    return this.http.get("https://localhost:7238/all-state");
  }


}
