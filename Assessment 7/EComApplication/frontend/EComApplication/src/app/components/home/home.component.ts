import { Component } from '@angular/core';
import { AdminDashboardComponent } from "../admin-dashboard/admin-dashboard.component";
import { CustomerDashboardComponent } from "../customer-dashboard/customer-dashboard.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [AdminDashboardComponent, CustomerDashboardComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  userDeatils = JSON.parse(localStorage.getItem('userDetails') || '{}');
  
}
