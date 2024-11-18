import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OpenTokService } from '../../services/OpenTok/open-tok.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {

  router = inject(Router)
  toaster = inject(ToastrService)
  isScreenSharing: boolean = false;

 
  // ngOnInit(): void {
  //   this.checkTokenExpiry();
  // }
  
  checkTokenExpiry() {
    const expiryTime = localStorage.getItem('expiry');
    
    if (expiryTime) {
      const expireIn = new Date(expiryTime);  
      const currentTime = new Date();  

      if (currentTime >= expireIn) {
        this.logout('auto'); 
      } else {
        
        const timeRemaining = expireIn.getTime() - currentTime.getTime();
        setTimeout(() => {
          this.logout('auto'); 
        }, timeRemaining);
      }
    } else {  
      this.logout('auto');
    }
  }

  logout(type: 'manual' | 'auto') {
    
    localStorage.clear();
    this.router.navigate(["/"]);  

    if (type === 'auto') {
      this.toaster.info("Your session has expired. You have been logged out automatically.", "Session Expired");
    } else if (type === 'manual') {
      this.toaster.success("You have successfully logged out.", "Logout Successful");
    }
  }

  apiKey = 'b669c86a'; // Replace with your actual API Key
  sessionId: string = "";
  token: string = "";

  constructor(private openTokService: OpenTokService) {}

  ngOnInit(): void {
    this.checkTokenExpiry();
    // Fetch sessionId from backend
    this.openTokService.getSessionId().subscribe(({ sessionId }) => {
      this.sessionId = sessionId;

      // Fetch token for the sessionId
      this.openTokService.getToken(sessionId).subscribe(({ token }) => {
        this.token = token;

        // Initialize session and publish stream
        this.openTokService.initSession(this.apiKey, sessionId, token);
        this.openTokService.publishStream('publisherDiv');
        this.openTokService.subscribeToStreams('subscriberDiv');
      });
    });
  }

  // Start screen sharing
  startScreenShare(): void {
    this.openTokService.shareScreen('screenDiv');
  }
  


}