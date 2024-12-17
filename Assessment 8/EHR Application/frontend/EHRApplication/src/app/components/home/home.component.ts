import { Component, inject, OnInit } from '@angular/core';
import { TitleCasePipe } from '@angular/common';
import { UserServiceService } from '../../services/user/user-service.service';
import { ProviderDashboardComponent } from "../dashboard/provider-dashboard/provider-dashboard.component";
import { PatientDashboardComponent } from "../dashboard/patient-dashboard/patient-dashboard.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TitleCasePipe, ProviderDashboardComponent, PatientDashboardComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  username = localStorage.getItem('username');
  userDetails: any;

  userServices = inject(UserServiceService);
  router = inject(Router)

  ngOnInit(): void {
    
    this.userServices.user$.subscribe((user: any) => {
      this.userDetails = user;
    });
    
  }
  
}
