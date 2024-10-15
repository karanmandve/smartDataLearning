import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  // constructor() { }

  http = inject(HttpClient);

  getAllDepartments(){
    return this.http.get("http://localhost:5058/api/DepartmentManagement");
  }


}
