import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CartComponent } from './components/cart/cart.component';

export const routes: Routes = [
    {path:"", redirectTo:"login-register", pathMatch:"full"},
    {path:"login-register", component:RegisterLoginComponent},
    {path:"forget-password", component:ForgetPasswordComponent},
    {path: "", component: LayoutComponent, children : [
        {path: "profile", component: ProfileComponent},
        {path: "home", component: HomeComponent},
        {path: "cart", component: CartComponent}
    ]},
    {path: "**", component: ErrorComponent}
];
