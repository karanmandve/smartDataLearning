
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, NgModule, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-file-upload',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './file-upload.component.html',
  styleUrl: './file-upload.component.css'
})
export class FileUploadComponent {
  uploadForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.uploadForm = this.fb.group({
      name: ['', Validators.required],
      file: [null, Validators.required],
    });
  }

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    this.uploadForm.patchValue({ file });
    this.uploadForm.get('file')?.updateValueAndValidity();
  }

  onSubmit() {
    if (this.uploadForm.valid) {
      const formData = new FormData();
      formData.append('name', this.uploadForm.get('name')?.value);
      formData.append('file', this.uploadForm.get('file')?.value);

      this.http
        .post('https://localhost:7112/api/User/upload-profile-image-azure', formData)
        .subscribe(
          (response: any) => console.log('Upload successful', response),
          (error: any) => console.error('Upload failed', error)
        );
    } else {
      alert('Please fill all required fields.');
    }
  }
}
