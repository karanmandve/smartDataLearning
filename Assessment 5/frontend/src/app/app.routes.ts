import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { ErrorComponent } from './components/error/error.component';
import { ProfileComponent } from './components/profile/profile.component';
import { authGuardGuard } from './guards/auth-guard.guard';

export const routes: Routes = [


    {
        path:'',
        redirectTo:'login',
        pathMatch:'full'
    },
    {
        path:'login',
        component:RegisterLoginComponent
    },
    {
        path:'dashboard',
        component: ProfileComponent,
        canActivate: [authGuardGuard]

    },
    {
        path:'**',
        component: ErrorComponent
    }
];
