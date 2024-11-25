import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  toaster: any = inject(ToastrService);
  router: any = inject(Router);

  logout(type: 'manual' | 'auto') {
    localStorage.clear();
    this.router.navigate(['/']);

    if (type === 'auto') {
      this.toaster.info(
        'Your session has expired. You have been logged out automatically.',
        'Session Expired'
      );
    } else if (type === 'manual') {
      this.toaster.success(
        'You have successfully logged out.',
        'Logout Successful'
      );
    }
  }
}
