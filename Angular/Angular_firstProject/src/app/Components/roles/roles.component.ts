import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent {

  // variables
  name: string = "Ayush Nighot";
  angularVersion: number = 18;
  currentDate: Date = new Date();
  inputType: string = "checkbox";
  selectedState: string = "";

  // function
  showWelcomAlert(){
    alert("Welcome in Angular 18");
  }

  showMessage(message: string){
    alert(message)
  }



}
