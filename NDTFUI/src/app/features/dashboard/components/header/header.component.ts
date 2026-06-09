import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UiService } from 'src/app/core/services/ui.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  userMenuOpen = false;

  constructor(
    private router: Router,
    private ui: UiService
  ) {}

  toggleSidebar() {
    this.ui.toggleSidebar();
  }

  toggleUserMenu() {
    this.userMenuOpen = !this.userMenuOpen;
  }

  openSettings() {
    this.userMenuOpen = false;
    this.router.navigate(['/settings']);
  }

  logout() {
    this.userMenuOpen = false;
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }
}