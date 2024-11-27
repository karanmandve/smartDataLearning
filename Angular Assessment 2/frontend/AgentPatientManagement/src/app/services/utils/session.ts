import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class UtilsService {
    private _session: boolean = true;
  
    getSession(): boolean {
      return this._session;
    }
  
    setSession(value: boolean) {
      this._session = value;
    }
  }