import { Component } from '@angular/core';
import { ApiServiceService } from 'src/app/Services/api-service.service';

@Component({
  selector: 'app-template-driven',
  templateUrl: './template-driven.component.html',
  styleUrls: ['./template-driven.component.scss']
})
export class TemplateDrivenComponent {
  constructor (private apiService: ApiServiceService){  }
  userData = {
    name: '',
    email: '',
    age: null
  };
  submitted: boolean = false;

getData(){
  this.apiService.getData().subscribe(
    (response) => {
      this.userData = response;
      console.log('Data fetched:', this.userData);
    },
    (error) => {
      console.error('Error fetching data:', error);
    }
  );
}

  onSubmit(form: any) {
    this.submitted = true;
    console.log('Form Submitted!', this.userData);
  }
}
