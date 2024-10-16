import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from '../Component/admin/admin.component';
import { AdminProfileComponent } from '../Component/admin-profile/admin-profile.component';

const routes: Routes = [
  {path:'', component:AdminComponent},
  {path:'profile', component:AdminProfileComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
