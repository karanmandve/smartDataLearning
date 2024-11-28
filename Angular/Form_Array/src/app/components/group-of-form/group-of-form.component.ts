import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-group-of-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './group-of-form.component.html',
  styleUrl: './group-of-form.component.css'
})
export class GroupOfFormComponent {
  stuentForm: any;

  constructor(private fb: FormBuilder) {
    this.stuentForm = this.fb.group({
      forms: new FormArray([
        this.createForm()
      ])
    });
  }

  createForm(): FormGroup {
    return this.fb.group({
      name: new FormControl(''),
      phones: new FormArray([
        new FormControl('')
      ])
    });
  }
  formNames = ['Form1'];

  addForm(): void {
    const newFormName = `Form${this.stuentForm.get('forms').length + 1}`;
    this.formNames.push(newFormName);
    (this.stuentForm.get('forms') as FormArray).push(this.createForm());
  }

  removeForm(index: number): void {
    (this.stuentForm.get('forms') as FormArray).removeAt(index);
  }

  addPhone(index: number): void {
    (this.stuentForm.get('forms').controls[index].get('phones') as FormArray).push(new FormControl(''));
  }

  removePhone(formIndex: number, phoneIndex: number): void {
    (this.stuentForm.get('forms').controls[formIndex].get('phones') as FormArray).removeAt(phoneIndex);
  }

  submit(): void {
    console.log(this.stuentForm.value);
  }

  ngOnInit(): void {
    console.log(this.stuentForm.value);
    console.log(this.stuentForm.valid);
  }
}
