import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';

export const routes: Routes = [
    {path : "", component: RegisterLoginComponent},
    {path : "profile", loadChildren : () => import("../app/modules/profile/profile.module").then(mod => mod.ProfileModule)}
];
