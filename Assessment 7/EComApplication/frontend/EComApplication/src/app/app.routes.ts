import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
    {path:"", redirectTo:"login-register", pathMatch:"full"},
    {path:"login-register", component:RegisterLoginComponent},
    {path: "", component: LayoutComponent, children : [
        {path: "profile", component: ProfileComponent},
        {path: "home", component: HomeComponent}
    ]},
    {path: "**", component: ErrorComponent}
];
