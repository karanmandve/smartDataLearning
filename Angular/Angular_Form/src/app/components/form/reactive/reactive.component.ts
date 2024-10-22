import { JsonPipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive',
  standalone: true,
  imports: [ReactiveFormsModule, JsonPipe],
  templateUrl: './reactive.component.html',
  styleUrl: './reactive.component.css'
})
export class ReactiveComponent {
  
  studentForm: FormGroup = new FormGroup({
    firstName: new FormControl("", [Validators.required, Validators.minLength(3)]), // by default null if not give empty string
    lastName: new FormControl(""),
    userName: new FormControl("test user name", [Validators.email]),
    // userName: new FormControl("test user name", [Validators.pattern("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")]),
    city: new FormControl(""),
    state: new FormControl(""),
    zipCode: new FormControl(""),
    isAcceptTerms: new FormControl(""),

  })

  formValue:any;

  onSubmit(){
    this.formValue = this.studentForm.value;
  }

  // resetForm(){
  //   this.studentForm = new FormGroup({
  //     firstName: new FormControl,
  //     lastName: '',
  //     userName: '',
  //     city: '',
  //     state: '',
  //     zipCode: "",
  //     isAcceptTerms : false
  //   })
  

}
