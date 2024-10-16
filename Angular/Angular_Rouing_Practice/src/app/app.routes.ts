import { Routes } from '@angular/router';
import { EmployeeComponent } from './Component/employee/employee.component';
import { TestingComponent } from './Component/testing/testing.component';

export const routes: Routes = [
    {
        path: 'add-emp',
        component: EmployeeComponent
    },
    {
        path: 'testing',
        component: TestingComponent
    }
    
];
