import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormComponent } from './components/reactive-form/reactive-form.component';
import { TemplateDrivenComponent } from './components/template-driven/template-driven.component';

const routes: Routes = [ { path: '',component: ReactiveFormComponent }, { path: 'reactive',component: ReactiveFormComponent }, { path: 'template',component: TemplateDrivenComponent},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
