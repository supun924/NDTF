import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UiService } from 'src/app/core/services/ui.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  sidebarOpen = false;
  activeMenu: string = 'dashboard';

  constructor(private ui: UiService, private router: Router) {

    // sidebar state
    this.ui.sidebarOpen$.subscribe(state => {
      this.sidebarOpen = state;
    });

    // 🔥 FIX: sync active menu with route
    this.router.events.subscribe(() => {
      const url = this.router.url;

      if (url.includes('traffic-fines')) {
        this.activeMenu = 'traffic-fines';
      }
      else if (url.includes('driving-license')) {
        this.activeMenu = 'driving-license';
      }
      else if (url.includes('payment-fines')) {
        this.activeMenu = 'payment-fines';
      }
      else {
        this.activeMenu = 'dashboard';
      }
    });

  }

  openDashboard() {
    this.activeMenu = 'dashboard';
    this.router.navigate(['/dashboard/dashboard-home']);
  }

  openTrafficFines() {
    this.activeMenu = 'traffic-fines';
    this.router.navigate(['/dashboard/traffic-fines']);
  }

  openDrivingLicense() {
    this.activeMenu = 'driving-license';
    this.router.navigate(['/dashboard/driving-license']);
  }

  openPaymentFines() {
    this.activeMenu = 'payment-fines';
    this.router.navigate(['/dashboard/payment-fines']);
  }
}
