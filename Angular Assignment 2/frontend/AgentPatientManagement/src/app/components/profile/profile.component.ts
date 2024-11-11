import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UtilsService } from '../../services/utils/session';
import { ToastrService } from 'ngx-toastr';

import { CountryStateServiceService } from '../../services/country-state-service/country-state-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserServiceService } from '../../services/user/user-service.service';
import { PatientServiceService } from '../../services/patient-service/patient-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterLink, CommonModule, ReactiveFormsModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  
  agentEmail: any = localStorage.getItem("email");
  encodedAgentEmail = encodeURIComponent(this.agentEmail);

  session = inject(UtilsService)
  router = inject(Router)
  toaster = inject(ToastrService)

  logout(){
    localStorage.clear()
    this.session.setSession(false)
    this.router.navigate(["/"])
    this.toaster.success("Logout Successfull", "Success")
  }
  
  
  patientService = inject(PatientServiceService);
  countryStateService: any = inject(CountryStateServiceService);
  agentService = inject(UserServiceService)
  agentDetails: any = [];
  allPatient: any[] = [];
  agentId: any = null;
  
  
  
  async getAgentDetails(){
    this.agentService.getUserDetails(this.agentEmail).subscribe({
      next: (res: any) => {
        this.agentDetails = res
        this.agentId = res.aId
        this.getPatients()
      },
      error: (error: any) => {
        alert("I am in error")
        console.log(error)
      }
    })
  }
  
  
  // constructor() {
  // }
  
  ngOnInit() {
    this.getAgentDetails();
    this.getAllCountry();
    this.loadState();
  }

  updatedMode: boolean = false;

  patientForm: FormGroup = new FormGroup({
    pId: new FormControl(0),
    patientId: new FormControl(0),
      firstName: new FormControl('', [
        Validators.required,
        Validators.minLength(3)
      ]),
      lastName: new FormControl(''),
      age: new FormControl('', [
        Validators.min(1),
        Validators.max(130)
      ]),
      gender: new FormControl(''),
      email: new FormControl('', Validators.email),
      phoneNumber: new FormControl(''),
      address: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(0),
      country: new FormControl(0),
      postalCode: new FormControl(''),
      bloodType: new FormControl(''),
      medications: new FormControl(''),
      lastVisitDate: new FormControl(new Date()),
      nextAppointmentDate: new FormControl(new Date()),
      insuranceProvider: new FormControl(''),
      insurancePolicyNumber: new FormControl(0),
      hasAgreeToTerms: new FormControl(true),
      isPatientActive: new FormControl(true),
      aId: new FormControl(0)
  });

  resetForm() {
    this.patientForm.reset({
      firstName: '',
      lastName: '',
      age: '',
      gender: '',
      email: '',
      phoneNumber: '',
      address: '',
      city: '',
      state: 0,
      country: 0,
      postalCode: '',
      bloodType: '',
      medications: '',
      lastVisitDate: new Date(),
      nextAppointmentDate: new Date(),
      insuranceProvider: '',
      insurancePolicyNumber: 0,
      hasAgreeToTerms: true,
      isPatientActive: true,
      aId: 0
    });
  }

  formValue: any;

  onSubmit() {
    this.formValue = this.patientForm.value;
    this.formValue.aId = this.agentDetails.aId
    this.addPatients(this.formValue);
    this.resetForm();
  }
  showSucess(message: string) {
    this.toaster.success(message, 'sucess', {
      closeButton: true,
    });
  }

  getPatients() {
    this.patientService.getAllPatient(this.agentId).subscribe({
      next: (res: any) => {
        this.allPatient = res;
        console.log(this.allPatient)
      },
      error: (error: any) => {
        alert(error);
      },
    });
  }

  addPatients(Patient: any) {
    this.patientService.addPatient(Patient).subscribe({
      next: (res) => {
        this.showSucess('Patient Added Successfully');
        this.getPatients();
        // alert(res.message)
      },
      error: (error) => {
        alert(JSON.stringify(error));
        this.toaster.error('Error While Adding Patient', 'Error');
      },
    });
  }

  updatePatient(PatientObj: any) {
    console.log(PatientObj);
    this.updatedMode = true;
    this.patientForm.patchValue(PatientObj);
  }

  onUpdate() {
    this.formValue = this.patientForm.value;
    this.formValue.aId = this.agentDetails.aId
    this.patientService.updatePatientById(this.formValue).subscribe({
      next: (res) => {
        this.showSucess('Patient Updated Successfully');
        // alert("Updation Successful")
        this.updatedMode = false;
        this.resetForm();
        this.getPatients();
      },
      error: (error) => {
        // alert("Updation Unsuccessful")
        this.toaster.error('Error While Updating Patient', 'Error');
      },
    });
  }


  // SOFT DELETE

  onDelete(Patient: any){

    let isConfirm: boolean = confirm("You really want to delete?");

    if (isConfirm){

      Patient.isPatientActive = false;
      this.formValue = Patient;
      this.formValue.aId = this.agentDetails.aId

      
      this.patientService.updatePatientById(this.formValue).subscribe({
        next: (res: any) => {
          this.showSucess('Patient Deleted Successfully');
          this.getPatients();
        },
        error: (error: any) => {
          // alert("Updation Unsuccessful")
          console.log(error)
          this.toaster.error('Error While Deleting Patient', 'Error');
        },
      });
    }else{

      this.toaster.error('Deletion Unsuccessful', 'Error');
    }
  }





  deletePatient(PatientId: number) {
    this.patientService.deletePatientById(PatientId).subscribe({
      next: (res) => {
        this.getPatients();
        // alert("Deleted Successfully")
        this.showSucess('Patient Deleted Successfully');
      },
      error: (error) => {
        // alert("Deletion Unsuccessfull")
        this.toaster.error('Error While Deleting Patient', 'Error');
      },
    });
  }


  allCountry : any [] = []


  getAllCountry(){
    this.countryStateService.getAllCountry().subscribe({
      next : (res: any) => {
        this.allCountry = res
      },
      error : (error: any) =>{
        alert("I am in error")
      }
      
    })
  }


  allState : any [] = []

  allStateByCountryId: any[] = []


  loadState(){
    this.countryStateService.getAllState().subscribe({
      next : (res:any) => {
        this.allState = res
      },
      error : (error: any) => {
        alert("I am in error")
      }
    })
  }

  onChange(countrId : any){
    this.countryStateService.getStateByCountryId(countrId).subscribe({
      next : (res:any) => {
        this.allStateByCountryId = res
      },
      error : (error: any) => {
        alert("I am in error")
      }
    })
  }




  getCountryName(countryId: number): string {
    const country = this.allCountry.find(c => c.countryId === countryId);
    return country ? country.name : 'Not Found';
  }

  getStateName(stateId: number): string {
    const state = this.allState.find(s => s.stateId === stateId);
    return state ? state.name : 'Not Found';
  }


}
