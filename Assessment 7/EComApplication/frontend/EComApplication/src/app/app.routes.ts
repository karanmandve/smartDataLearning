import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CartComponent } from './components/cart/cart.component';
import { OrderComponent } from './components/order/order.component';
import { authGuardGuard } from './guards/auth-guard.guard';

export const routes: Routes = [
    {path:"", redirectTo:"login-register", pathMatch:"full"},
    {path:"login-register", component:RegisterLoginComponent},
    {path: "", component: LayoutComponent, children : [
        {path: "profile", component: ProfileComponent, canActivate : [authGuardGuard]},
        {path: "home", component: HomeComponent, canActivate : [authGuardGuard]},
        {path: "cart", component: CartComponent, canActivate : [authGuardGuard]},
        {path: "orders", component: OrderComponent, canActivate : [authGuardGuard]}
    ]},
    {path: "**", component: ErrorComponent}
];
