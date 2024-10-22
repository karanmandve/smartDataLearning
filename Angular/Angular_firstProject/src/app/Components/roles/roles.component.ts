import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IEmployee } from '../../Model/interface/employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent implements OnInit{

  // variables
  // name: string = "Ayush Nighot";
  // angularVersion: number = 18;
  // currentDate: Date = new Date();
  // inputType: string = "checkbox";
  // selectedState: string = "";

  // // function
  // showWelcomAlert(){
  //   alert("Welcome in Angular 18");
  // }

  // showMessage(message: string){
  //   alert(message)
  // }



  // HTTP CLIENT
  // LIFE CYCLE EVENT ON EVENT


  // OLD WAY getting http client

  // constructor(private http: HttpClient){

  // }

  // NEW WAY getting http client
  employeeList: IEmployee [] = [];
  http = inject(HttpClient);


  ngOnInit(): void {
    this.getAllEmployee();
  }

  getAllEmployee(){
    // to catch the data we need to use subscribe method
    this.http.get("http://localhost:5058/api/EmployeeManagement").subscribe((res:any) => {
      this.employeeList = res;
    })
  }


}
