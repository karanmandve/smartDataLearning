import { Component } from '@angular/core';
import { AdminDashboardComponent } from "../admin-dashboard/admin-dashboard.component";
import { CustomerDashboardComponent } from "../customer-dashboard/customer-dashboard.component";
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [AdminDashboardComponent, CustomerDashboardComponent, TitleCasePipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  userDeatils = JSON.parse(localStorage.getItem('userDetails') || '{}');
  
}
