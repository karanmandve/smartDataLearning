import { Routes } from '@angular/router';
import { RegisterLoginComponent } from './components/register-login/register-login.component';
import { ErrorComponent } from './components/error/error.component';
import { authGuardGuard } from './guards/auth-guard.guard';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChatComponent } from './components/chat/chat.component';
import { ProfileComponent } from './components/profile/profile.component';

export const routes: Routes = [
    {path: "", component: RegisterLoginComponent},
    {path:'dashboard', component: DashboardComponent, canActivate: [authGuardGuard]},
    {path:'chat', component: ChatComponent, canActivate: [authGuardGuard]},
    {path:'profile', component: ProfileComponent, canActivate: [authGuardGuard]},
    {path: "**", component: ErrorComponent}
];
