import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-form-array',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './form-array.component.html',
  styleUrl: './form-array.component.css'
})
export class FormArrayComponent {
 form: FormGroup = new FormGroup({
  id: new FormControl(""),
  mobileNumber: new FormArray([
    new FormControl()
  ])
 })

 newForm: FormGroup = new FormGroup({
  id: new FormControl(""),
  form: new FormArray([
    new FormGroup({
      name: new FormControl(""),
      age: new FormControl(""),
      phone: new FormArray([
        new FormControl()
      ])
    })
  ])
 })

 get newFormFunction(): FormArray {
  return this.form.get('form') as FormArray;
}

 // Method to add a new mobile number control to the FormArray
 addNewForm(): void {
  this.newFormFunction.push(new FormGroup({
    name: new FormControl(""),
    age: new FormControl(""),
    phone: new FormArray([
      new FormControl()
    ])
  }));
}


 get mobileNumbers(): FormArray {
   return this.form.get('mobileNumber') as FormArray;
 }

 // Method to add a new mobile number control to the FormArray
 addMobileNumber(): void {
   this.mobileNumbers.push(new FormControl());
 }

 removePhoneNumber(index: number) {
  (this.form.get('phoneNumbers') as FormArray).removeAt(index);
}


}
