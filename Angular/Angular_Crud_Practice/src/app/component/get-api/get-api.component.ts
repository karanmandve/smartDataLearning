import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-get-api',
  standalone: true,
  imports: [],
  templateUrl: './get-api.component.html',
  styleUrl: './get-api.component.css'
})
export class GetApiComponent {

  userList: any[] = []

  http = inject(HttpClient)

  getAllUser() {
    this.http.get("http://localhost:5058/api/EmployeeManagementd").subscribe({
      next: (res: any) => {
        this.userList = res
      },
      error: (error) => {
        alert("API Error/ Network Error")
        console.log(error);
      }
    })
  }

}
