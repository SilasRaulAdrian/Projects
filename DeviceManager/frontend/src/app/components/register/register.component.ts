import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
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
          <h1>Create Account</h1>
          <p>Join DeviceManager today</p>
        </div>

        <div *ngIf="errorMsg" class="alert alert-error">{{ errorMsg }}</div>

        <form [formGroup]="form" (ngSubmit)="onSubmit()">
          <div class="form-grid">
            <div class="form-group">
              <label class="form-label">Full Name</label>
              <input type="text" formControlName="name" class="form-control"
                [class.is-invalid]="isInvalid('name')" placeholder="John Doe">
              <div *ngIf="isInvalid('name')" class="invalid-feedback">Name is required.</div>
            </div>
            <div class="form-group">
              <label class="form-label">Role</label>
              <select formControlName="role" class="form-control" [class.is-invalid]="isInvalid('role')">
                <option value="">Select role...</option>
                <option value="Developer">Developer</option>
                <option value="QA Engineer">QA Engineer</option>
                <option value="Manager">Manager</option>
                <option value="Designer">Designer</option>
                <option value="Employee">Employee</option>
              </select>
              <div *ngIf="isInvalid('role')" class="invalid-feedback">Role is required.</div>
            </div>
          </div>

          <div class="form-group">
            <label class="form-label">Email address</label>
            <input type="email" formControlName="email" class="form-control"
              [class.is-invalid]="isInvalid('email')" placeholder="you@company.com">
            <div *ngIf="isInvalid('email')" class="invalid-feedback">Valid email is required.</div>
          </div>

          <div class="form-group">
            <label class="form-label">Location</label>
            <input type="text" formControlName="location" class="form-control"
              [class.is-invalid]="isInvalid('location')" placeholder="e.g. HQ - Floor 2">
            <div *ngIf="isInvalid('location')" class="invalid-feedback">Location is required.</div>
          </div>

          <div class="form-group">
            <label class="form-label">Password</label>
            <input type="password" formControlName="password" class="form-control"
              [class.is-invalid]="isInvalid('password')" placeholder="Min 6 characters">
            <div *ngIf="isInvalid('password')" class="invalid-feedback">Password must be at least 6 characters.</div>
          </div>

          <button type="submit" class="btn btn-primary" style="width:100%; justify-content:center; margin-top:8px"
            [disabled]="loading">
            <span *ngIf="loading" class="spinner"></span>
            {{ loading ? 'Creating account...' : 'Create account' }}
          </button>
        </form>

        <div class="auth-link">
          Already have an account? <a routerLink="/login">Sign in</a>
        </div>
      </div>
    </div>
  `
})

export class RegisterComponent {
    form: FormGroup;
    loading = false
    errorMsg: string = '';

    constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
        this.form = this.fb.group({
            name: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            role: ['', Validators.required],
            location: ['', Validators.required]
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
        this.authService.register(this.form.value).subscribe({
            next: () => this.router.navigate(['/devices']),
            error: (err) => {
                this.errorMsg = err.status === 409 ? 'Email is already registered.' : 'Registration failed.';
                this.loading = false;
            }
        });
    }
}