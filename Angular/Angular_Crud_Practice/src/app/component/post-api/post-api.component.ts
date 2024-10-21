import { JsonPipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-api',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './post-api.component.html',
  styleUrl: './post-api.component.css'
})
export class PostApiComponent {
  
  studentForm: FormGroup = new FormGroup({
    employeeFirstName: new FormControl(""),
    employeeLastName: new FormControl(""),
    salary: new FormControl(""),
    departmentId: new FormControl("")

  })

  formValue:any;

  onSubmit(){
    this.formValue = this.studentForm.value;
  }

}
