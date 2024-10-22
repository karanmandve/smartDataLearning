import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PatientServiceService } from '../../services/patient-service/patient-service.service';
import { ToastrService } from 'ngx-toastr';
import { dateTimestampProvider } from 'rxjs/internal/scheduler/dateTimestampProvider';

@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './patient.component.html',
  styleUrl: './patient.component.css'
})
export class PatientComponent {

  patientService = inject(PatientServiceService)
  toaster = inject(ToastrService)
  allPatient: any [] = [];


  ngOnInit(): void {
    this.getPatients();
  }

  updatedMode: boolean = false;
  
  
  patientForm: FormGroup = new FormGroup({
    patientId: new FormControl(0),
    firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    lastName: new FormControl(''),
    age: new FormControl(0, [Validators.min(0), Validators.max(130)]),
    gender: new FormControl(''),
    email: new FormControl('', [Validators.email]),
    phoneNumber: new FormControl(''),
    address: new FormControl(''),
    city: new FormControl(''),
    state: new FormControl(''),
    country: new FormControl(''),
    postalCode: new FormControl(''),
    bloodType: new FormControl(''),
    height: new FormControl(0, [Validators.min(0)]),
    weight: new FormControl(0, [Validators.min(0)]),
    medications: new FormControl(''),
    lastVisitDate: new FormControl(''),
    nextAppointmentDate: new FormControl(''),
    insuranceProvider: new FormControl(''),
    insurancePolicyNumber: new FormControl(0),
    isPatientActive: new FormControl(true)
})


resetForm() {
  this.patientForm.reset({
    patientId: 0,
  firstName: '',
  lastName: '',
  age: 0,
  gender: '',
  email: '',
  phoneNumber: '',
  address: '',
  city: '',
  state: '',
  country: '',
  postalCode: '',
  bloodType: '',
  height: 0,
  weight: 0,
  medications: '',
  lastVisitDate: '',
  nextAppointmentDate: '',
  insuranceProvider: '',
  insurancePolicyNumber: 0,
  isPatientActive: true
  });
}


formValue:any;

  onSubmit(){
    this.formValue = this.patientForm.value;
    this.addPatients(this.formValue);
    this.resetForm()
  }

  getPatients(){
    this.patientService.getAllPatient().subscribe({

      next : (res: any) => {
        this.allPatient = res;
      },
      error : (error: any) => {
        alert(error);
      }
      })
  }


   addPatients(customer: any){
    this.patientService.addPatient(customer).subscribe({
      next : (res: any) => {
        this.toaster.success("Patient Added Successfully", "Success")
        this.getPatients()
        // alert(res.message)
      },
      error : (error: any) => {
        // alert("i am error")
        this.toaster.error("Patient Not Added", "Error")
        // alert(JSON.stringify(error))
      }
    })
  }

  updatePatient(patientObj: any){
    this.updatedMode = true
    this.patientForm.patchValue(patientObj);
  }

  onUpdate(){
    this.formValue = this.patientForm.value;
    this.patientService.updatePatientById(this.formValue).subscribe({
      next : (res:any) => {
        this.toaster.success("Patient Updated Successfully", "Success")
        this.getPatients()
        // alert("Updation Successful")
        this.updatedMode = false
        this.resetForm()
      },
      error : (error:any) => {
        // alert("I am error")
        this.toaster.error("Patient Not Updated", "Error")
        // alert(JSON.stringify(error))
        // alert("Updation Unsuccessful")
      }
    })
  }


      // SOFT DELETE


      onDelete(patient: any){

        let isConfirm: boolean = confirm("You really want to delete?");
    
        if (isConfirm){
    
          patient.isPatientActive = false;
          this.formValue = patient;
          
          this.patientService.updatePatientById(this.formValue).subscribe({
            next: (res) => {
              this.toaster.success("Patient Deleted Successfully", "Success")
              this.getPatients();
            },
            error: (error) => {
              // alert("Updation Unsuccessful")
              this.toaster.error('Error While Deleting Patient', 'Error');
            },
          });
        }else{
    
          this.toaster.error('Deletion Unsuccessful', 'Error');
        }
      }
    
  



  // deletePatient(customerId: number){
  //   this.patientService.deletePatientById(customerId).subscribe({
  //     next : (res:any) => {
  //       this.getPatients()
  //       // alert("Deleted Successfully")
  //       this.toaster.success("Patient Deleted Successfully", "Success")

  //     },
  //     error : (error:any) => {
  //       // alert("Deletion Unsuccessfull")
  //       this.toaster.error("Patient Not Deleted", "Error")
  //     }
  //   })
  // }



}
