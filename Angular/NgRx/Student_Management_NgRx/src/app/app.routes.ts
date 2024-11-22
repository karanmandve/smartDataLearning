import { Routes } from '@angular/router';
import { StudentComponent } from './component/student/student.component';
import { PracticalComponent } from './component/practical/practical.component';

export const routes: Routes = [
    {path: "", component: StudentComponent},
    {path: "practical", component: PracticalComponent}
];
