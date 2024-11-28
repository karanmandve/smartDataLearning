import { Routes } from '@angular/router';
import { FormArrayComponent } from './components/form-array/form-array.component';
import { GroupOfFormComponent } from './components/group-of-form/group-of-form.component';

export const routes: Routes = [
    {path: "", component: FormArrayComponent},
    {path: "group-of-form", component: GroupOfFormComponent},

];
