import { Routes } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { ErrorComponent } from './Component/error/error.component';
import { UserComponent } from './Component/user/user.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'user',
    component: UserComponent,
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then((mod) => mod.AdminModule),
  },
  {
    path: '**',
    component: ErrorComponent,
  },
];
