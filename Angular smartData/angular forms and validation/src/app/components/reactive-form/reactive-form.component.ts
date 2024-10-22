import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiServiceService } from 'src/app/Services/api-service.service';

@Component({
  selector: 'app-reactive-form',
  templateUrl: './reactive-form.component.html',
  styleUrls: ['./reactive-form.component.scss']
})
export class ReactiveFormComponent {

  userForm: FormGroup;
  submitted: boolean = false;
  formData: any = {};

  constructor(private fb: FormBuilder,private apiService: ApiServiceService) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      age: ['']
    });
  }

  ngOnInit(): void {}
  onSubmit() {
    this.submitted = true;
    this.formData = this.userForm.value;
    this.apiService.postData(this.formData).subscribe(
      (response) => {
        console.log('Data submitted:', response);
      },
      (error) => {
        console.error('Error submitting data:', error);
      }
    );
  }
}

