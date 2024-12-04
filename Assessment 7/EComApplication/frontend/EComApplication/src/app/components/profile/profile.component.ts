import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  profileData: any;
  
  ngOnInit(): void {  
    this.profileData = JSON.parse(localStorage.getItem("userDetails") || '{}'); 
    
    
  }


  onImageChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      // Simulate image upload and update profile image
      const reader = new FileReader();
      reader.onload = () => {
        this.profileData.profileImageUrl = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  editProfile(): void {
    alert('Edit Profile functionality not yet implemented.');
  }

  changePassword(): void {
    alert('Change Password functionality not yet implemented.');
  }
}
