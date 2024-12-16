import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { authGuardGuard } from './guards/auth-guard.guard';
import { ErrorComponent } from './components/error/error.component';

export const routes: Routes = [
    {path:"", redirectTo:"login-register", pathMatch:"full"},
    {path:"login-register", component:RegisterLoginComponent},
    {path: "", component: LayoutComponent, children : [
        {path: "profile", component: ProfileComponent, canActivate : [authGuardGuard]},
        {path: "home", component: HomeComponent, canActivate : [authGuardGuard]},
    ]},
    {path: "**", component: ErrorComponent}
];
