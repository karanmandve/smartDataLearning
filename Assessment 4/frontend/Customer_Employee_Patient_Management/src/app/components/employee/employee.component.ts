import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeServiceService } from '../../services/employee-service/employee-service.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
  employeeService = inject(EmployeeServiceService)
  toaster = inject(ToastrService)
  allEmployee: any [] = [];

  /**
   *
   */
  // constructor() {
  //   this.getEmployees()
    
  // }

  ngOnInit(): void {
    this.getEmployees();
  }

  updatedMode: boolean = false;

  employeeForm: FormGroup = new FormGroup({
    employeeId: new FormControl(0),
    firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    lastName: new FormControl(''),
    age: new FormControl(),
    email: new FormControl('', [Validators.email]),
    gender: new FormControl(''),
    jobTitle: new FormControl(''),
    department: new FormControl(''),
    salary: new FormControl([Validators.min(0)]),
    hireDate: new FormControl(''),
    address: new FormControl(''),
    city: new FormControl(''),
    state: new FormControl(''),
    postalCode: new FormControl(''),
    country: new FormControl(''),
    phoneNumber: new FormControl(''),
    startDate: new FormControl(''),
    benefitsPackage: new FormControl(''),
    vacationDays: new FormControl([Validators.min(0)]),
    performanceRating: new FormControl([Validators.min(0), Validators.max(5)]),
    isEmployeeActive: new FormControl(true)
  });

  resetForm (){
    this.employeeForm.reset({
      employeeId: 0,
      firstName: '',
      lastName: '',
      age: 0,
      email: '',
      gender: '',
      jobTitle: '',
      department: '',
      salary: 0,
      hireDate: '',
      address: '',
      city: '',
      state: '',
      postalCode: '',
      country: '',
      phoneNumber: '',
      startDate: '',
      benefitsPackage: '',
      vacationDays: 0,
      performanceRating: 0,
      isEmployeeActive: true
    })
  }


  formValue:any;

  onSubmit(){
    this.formValue = this.employeeForm.value;
    this.addEmployees(this.formValue);
    this.resetForm()
    this.getEmployees() 
  }

  getEmployees(){
    this.employeeService.getAllEmployee().subscribe({

      next : (res: any) => {
        this.allEmployee = res;
      },
      error : (error: any) => {
        alert(error);
      }
      })
  }


   addEmployees(employee: any){
    this.employeeService.addEmployee(employee).subscribe({
      next : (res: any) => {
        this.toaster.success("Employee Added Successfully", "Success")
        this.getEmployees()
        // alert(res.message)
      },
      error : (error: any) => {
        // alert("i am error")
        this.toaster.error("Employee Not Added", "Error")
        alert(JSON.stringify(error))
      }
    })
  }

  updateEmployee(employeeObj: any){
    this.updatedMode = true
    this.employeeForm.patchValue(employeeObj);
  }

  onUpdate(){
    this.formValue = this.employeeForm.value;
    this.employeeService.updateEmployeeById(this.formValue).subscribe({
      next : (res:any) => {
        this.getEmployees()
        this.toaster.success("Employee Updated Successfully", "Success")
        // alert("Updation Successful")
        this.updatedMode = false
        this.resetForm()
      },
      error : (error:any) => {
        this.toaster.error("Employee Not Updated", "Error")
        // alert("Updation Unsuccessful")
      }
    })
  }

    // SOFT DELETE


    onDelete(employee: any){

      let isConfirm: boolean = confirm("You really want to delete?");
  
      if (isConfirm){
  
        employee.isEmployeeActive = false;
        this.formValue = employee;
        
        this.employeeService.updateEmployeeById(this.formValue).subscribe({
          next: (res) => {
            this.toaster.success("Employee Deleted Successfully", "Success")
            this.getEmployees();
          },
          error: (error) => {
            // alert("Updation Unsuccessful")
            this.toaster.error('Error While Deleting Employee', 'Error');
          },
        });
      }else{
  
        this.toaster.error('Deletion Unsuccessful', 'Error');
      }
    }
  



  // deleteEmployee(employeeId: number){
  //   this.employeeService.deleteEmployeeById(employeeId).subscribe({
  //     next : (res:any) => {
  //       this.getEmployees()
  //       this.toaster.success("Employee Deleted Successfully", "Success")
  //       // alert("Deleted Successfully")
  //     },
  //     error : (error:any) => {
  //       this.toaster.error("Employee Not Deleted", "Error")
  //       // alert("Deletion Unsuccessfull")
  //     }
  //   })
  // }
}
