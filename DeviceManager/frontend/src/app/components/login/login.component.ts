import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  template: `
    <div class="auth-wrapper">
      <div class="auth-card">
        <div class="auth-logo">
          <svg width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="#2563eb" stroke-width="1.5">
            <rect x="5" y="2" width="14" height="20" rx="2"/>
            <line x1="12" y1="18" x2="12" y2="18.01" stroke-width="2.5"/>
          </svg>
          <h1>DeviceManager</h1>
          <p>Sign in to your account</p>
        </div>

        <div *ngIf="errorMsg" class="alert alert-error">{{ errorMsg }}</div>

        <form [formGroup]="form" (ngSubmit)="onSubmit()">
          <div class="form-group">
            <label class="form-label">Email address</label>
            <input type="email" formControlName="email" class="form-control"
              [class.is-invalid]="isInvalid('email')" placeholder="you@company.com">
            <div *ngIf="isInvalid('email')" class="invalid-feedback">Valid email is required.</div>
          </div>

          <div class="form-group">
            <label class="form-label">Password</label>
            <input type="password" formControlName="password" class="form-control"
              [class.is-invalid]="isInvalid('password')" placeholder="••••••••">
            <div *ngIf="isInvalid('password')" class="invalid-feedback">Password is required.</div>
          </div>

          <button type="submit" class="btn btn-primary" style="width:100%; justify-content:center; margin-top:8px"
            [disabled]="loading">
            <span *ngIf="loading" class="spinner"></span>
            {{ loading ? 'Signing in...' : 'Sign in' }}
          </button>
        </form>

        <div class="auth-link">
          Don't have an account? <a routerLink="/register">Register here</a>
        </div>
      </div>
    </div>
  `
})

export class LoginComponent {
    form: FormGroup;
    loading = false
    errorMsg: string = '';

    constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private cdr: ChangeDetectorRef) {
        this.form = this.fb.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required]
        });
    }

    isInvalid(field: string): boolean {
        const ctrl = this.form.get(field);
        return !!(ctrl?.invalid && ctrl?.touched);
    }

    onSubmit() {
        if (this.form.invalid) { this.form.markAllAsTouched(); return; }
        this.loading = true;
        this.errorMsg = '';
        this.authService.login(this.form.value).subscribe({
            next: () => this.router.navigate(['/devices']),
            error: () => {
                this.showError('Invalid email or password.');
                this.loading = false;
            }
        });
    }

    private showError(msg: string): void {
        this.errorMsg = msg;
        this.cdr.detectChanges();
        setTimeout(() => { this.errorMsg = ''; this.cdr.detectChanges(); }, 3000);
    }
}
