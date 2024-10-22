import { Routes } from '@angular/router';
import { CustomerComponent } from './components/customer/customer.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { PatientComponent } from './components/patient/patient.component';
import { ErrorComponent } from './components/error/error.component';

export const routes: Routes = [

    {
        path: '',
        component: CustomerComponent,
      },
    //   FOR LAZY LOADING THE DATA FOR EMPLOYEE AND PATIENT
      {
        path: 'employee',
        loadChildren: () => import("./employee/employee.module").then((m) => m.EmployeeModule),
      },
      {
        path: 'patient',
        loadChildren: () => import("./patient/patient.module").then((m) => m.PatientModule),
      },
      {
        path: '**',
        component: ErrorComponent,
      },

];
