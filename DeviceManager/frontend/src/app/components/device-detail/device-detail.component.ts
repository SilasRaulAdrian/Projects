import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Device } from '../../models/models';
import { DeviceService } from '../../services/device.service';
import { AuthService } from '../../services/auth.service';
import { DeviceFormComponent } from '../device-form/device-form.component';

@Component({
  selector: 'app-device-detail',
  standalone: true,
  imports: [CommonModule, DeviceFormComponent],
  template: `
    <div class="page-container">
      <div style="margin-bottom:20px">
        <button class="btn btn-secondary btn-sm" (click)="goBack()">
          ← Back to Devices
        </button>
      </div>

      <div *ngIf="loading" class="loading-state">
        <div class="spinner"></div> Loading device...
      </div>

      <div *ngIf="!loading && !device" class="card card-body" style="text-align:center; padding:48px">
        <p style="color:var(--gray-500)">Device not found.</p>
      </div>

      <div *ngIf="!loading && device">
        <div *ngIf="successMsg" class="alert alert-success">{{ successMsg }}</div>
        <div *ngIf="errorMsg" class="alert alert-error">{{ errorMsg }}</div>

        <!-- Header card -->
        <div class="card" style="margin-bottom:20px">
          <div class="card-header">
            <div style="display:flex; align-items:center; gap:16px">
              <div style="background:var(--primary-light); border-radius:12px; padding:12px; font-size:28px">
                {{ device.type === 'phone' ? '📱' : '📋' }}
              </div>
              <div>
                <h1 style="font-size:22px; font-weight:700; color:var(--gray-900)">{{ device.name }}</h1>
                <p style="color:var(--gray-500)">{{ device.manufacturer }}</p>
              </div>
              <span class="badge" style="margin-left:8px"
                [class.badge-phone]="device.type === 'phone'"
                [class.badge-tablet]="device.type === 'tablet'">
                {{ device.type }}
              </span>
            </div>
            <div style="display:flex; gap:8px">
              <button class="btn btn-secondary" (click)="showEditForm = true">✏️ Edit</button>
              <button class="btn btn-danger" (click)="confirmDelete = true">🗑️ Delete</button>
            </div>
          </div>
        </div>

        <!-- Specs + assignment -->
        <div style="display:grid; grid-template-columns: 2fr 1fr; gap:20px; flex-wrap:wrap">
          <div class="card">
            <div class="card-header"><h3 style="font-size:16px; font-weight:600">Specifications</h3></div>
            <div class="card-body">
              <table style="width:100%; border-collapse:collapse">
                <tbody>
                  <tr *ngFor="let spec of specs" style="border-bottom:1px solid var(--gray-100)">
                    <td style="padding:10px 0; color:var(--gray-500); font-size:13px; width:140px">{{ spec.label }}</td>
                    <td style="padding:10px 0; color:var(--gray-800); font-weight:500">{{ spec.value }}</td>
                  </tr>
                </tbody>
              </table>
              <div *ngIf="device.description" style="margin-top:16px; padding-top:16px; border-top:1px solid var(--gray-200)">
                <div style="color:var(--gray-500); font-size:13px; margin-bottom:6px">Description</div>
                <p style="color:var(--gray-700)">{{ device.description }}</p>
              </div>
            </div>
          </div>

          <div class="card">
            <div class="card-header"><h3 style="font-size:16px; font-weight:600">Assignment</h3></div>
            <div class="card-body">
              <div *ngIf="device.assignedToUserName" style="margin-bottom:16px">
                <div style="color:var(--gray-500); font-size:12px; margin-bottom:4px">Currently assigned to</div>
                <div style="display:flex; align-items:center; gap:8px; padding:12px; background:var(--success-light); border-radius:8px">
                  <span style="font-size:20px">👤</span>
                  <span style="font-weight:600; color:var(--gray-800)">{{ device.assignedToUserName }}</span>
                </div>
              </div>
              <div *ngIf="!device.assignedToUserName" style="margin-bottom:16px">
                <div style="padding:12px; background:var(--gray-100); border-radius:8px; text-align:center; color:var(--gray-500)">
                  This device is available
                </div>
              </div>

              <div style="display:flex; flex-direction:column; gap:8px">
                <button class="btn btn-success" (click)="assignToMe()"
                  *ngIf="!device.assignedToUserId" [disabled]="assigning">
                  <span *ngIf="assigning" class="spinner" style="width:14px;height:14px;border-width:1.5px"></span>
                  Assign to Me
                </button>
                <button class="btn btn-secondary" (click)="unassign()"
                  *ngIf="device.assignedToUserId === currentUserId" [disabled]="assigning">
                  <span *ngIf="assigning" class="spinner" style="width:14px;height:14px;border-width:1.5px"></span>
                  Unassign from Me
                </button>
                <p *ngIf="device.assignedToUserId && device.assignedToUserId !== currentUserId"
                  style="font-size:12px; color:var(--gray-400); text-align:center">
                  Assigned to another user
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Edit modal -->
    <app-device-form *ngIf="showEditForm" [device]="device"
      (saved)="onSaved($event)" (cancelled)="showEditForm = false">
    </app-device-form>

    <!-- Delete confirm -->
    <div class="modal-overlay" *ngIf="confirmDelete" (click)="confirmDelete = false">
      <div class="modal" style="max-width:400px" (click)="$event.stopPropagation()">
        <div class="modal-header">
          <h2>Delete Device</h2>
          <button class="close-btn" (click)="confirmDelete = false">&#x2715;</button>
        </div>
        <div class="modal-body">
          <p>Are you sure you want to delete <strong>{{ device?.name }}</strong>? This cannot be undone.</p>
        </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" (click)="confirmDelete = false">Cancel</button>
          <button class="btn btn-danger" (click)="deleteDevice()" [disabled]="deleting">
            <span *ngIf="deleting" class="spinner"></span>
            {{ deleting ? 'Deleting...' : 'Delete' }}
          </button>
        </div>
      </div>
    </div>
  `
})

export class DeviceDetailComponent implements OnInit {
    device: Device | null = null;
    loading = true;
    showEditForm = false;
    confirmDelete = false;
    assigning = false;
    deleting = false;
    successMsg: string = '';
    errorMsg: string = '';

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private deviceService: DeviceService,
        private authService: AuthService
    ) {}
    
    get currentUserId(): number | undefined {
        return this.authService.currentUser?.id;
    }

    get specs() {
        if (!this.device) return [];
        return [
            { label: 'Manufacturer', value: this.device.manufacturer },
            { label: 'Type', value: this.device.type },
            { label: 'Operating System', value: this.device.operatingSystem },
            { label: 'OS Version', value: this.device.osVersion },
            { label: 'Processor', value: this.device.processor },
            { label: 'RAM', value: this.device.ramAmount },
        ];
    }

    ngOnInit(): void {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        this.deviceService.getById(id).subscribe({
            next: (d) => {
                this.device = d;
                this.loading = false;
            },
            error: () => {
                this.loading = false;
            }
        });
    }

    goBack(): void {
        this.router.navigate(['/devices']);
    }

    onSaved(updated: Device): void {
        this.device = updated;
        this.showEditForm = false;
        this.showSuccess('Device updated successfully.');
    }

    assignToMe(): void {
        if (!this.device) return;
        this.assigning = true;
        this.deviceService.assign(this.device.id).subscribe({
            next: () => {
                this.reload();
                this.showSuccess('Device assigned to you.');
            },
            error: () => {
                this.assigning = false;
                this.errorMsg = 'Could not assign device.';
            }
        });
    }

    unassign(): void {
        if (!this.device) return;
        this.assigning = true;
        this.deviceService.unassign(this.device.id).subscribe({
            next: () => {
                this.reload();
                this.showSuccess('Device unassigned.');
            },
            error: () => {
                this.assigning = false;
                this.errorMsg = 'Could not unassign device.';
            }
        });
    }

    deleteDevice(): void {
        if (!this.device) return;
        this.deleting = true;
        this.deviceService.delete(this.device.id).subscribe({
            next : () => {
                this.router.navigate(['/devices']);
            },
            error: () => {
                this.deleting = false;
                this.errorMsg = 'Failed to delete.';
            }
        });
    }

    private reload(): void {
        this.assigning = false;
        const id = this.device!.id;
        this.deviceService.getById(id).subscribe(d => this.device = d);
    }

    private showSuccess(msg: string): void {
        this.successMsg = msg;
        setTimeout(() => this.successMsg = '', 3000);
    }
}