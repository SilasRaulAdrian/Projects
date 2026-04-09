import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <nav class="navbar">
      <div class="navbar-inner">
        <a routerLink="/devices" class="navbar-brand">
          <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <rect x="5" y="2" width="14" height="20" rx="2"/>
            <line x1="12" y1="18" x2="12" y2="18.01"/>
          </svg>
          DeviceManager
        </a>
        <div class="navbar-user">
          <span class="user-info">
            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
              <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"/>
              <circle cx="12" cy="7" r="4"/>
            </svg>
            {{ user?.name }}
            <span class="role-badge">{{ user?.role }}</span>
          </span>
          <button class="btn btn-secondary btn-sm" (click)="logout()">
            Logout
          </button>
        </div>
      </div>
    </nav>
  `,
  styles: [`
    .navbar {
      background: #fff;
      border-bottom: 1px solid var(--gray-200);
      box-shadow: var(--shadow-sm);
      position: sticky;
      top: 0;
      z-index: 100;
    }
    .navbar-inner {
      max-width: 1200px;
      margin: 0 auto;
      padding: 0 16px;
      height: 56px;
      display: flex;
      align-items: center;
      justify-content: space-between;
    }
    .navbar-brand {
      display: flex;
      align-items: center;
      gap: 8px;
      font-weight: 700;
      font-size: 16px;
      color: var(--primary);
      text-decoration: none;
    }
    .navbar-user {
      display: flex;
      align-items: center;
      gap: 12px;
    }
    .user-info {
      display: flex;
      align-items: center;
      gap: 6px;
      color: var(--gray-600);
      font-size: 14px;
    }
    .role-badge {
      background: var(--primary-light);
      color: var(--primary);
      padding: 2px 8px;
      border-radius: 20px;
      font-size: 11px;
      font-weight: 600;
    }
  `]
})

export class NavbarComponent {
    constructor(private authService: AuthService, private router: Router) {}
    get user() {
        return this.authService.currentUser;
    }
    logout() {
        this.authService.logout();
        this.router.navigate(['/login']);
    }
}