import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Device } from '../../models/models';
import { DeviceService } from '../../services/device.service';
import { AuthService } from '../../services/auth.service';
import { DeviceFormComponent } from '../device-form/device-form.component';

@Component({
  selector: 'app-device-list',
  standalone: true,
  imports: [CommonModule, FormsModule, DeviceFormComponent],
  template: `
    <div class="page-container">
      <!-- Header -->
      <div style="display:flex; align-items:center; justify-content:space-between; margin-bottom:24px; flex-wrap:wrap; gap:12px">
        <div>
          <h1 style="font-size:24px; font-weight:700; color:var(--gray-900)">Devices</h1>
          <p style="color:var(--gray-500); margin-top:2px">{{ devices.length }} device{{ devices.length !== 1 ? 's' : '' }} total</p>
        </div>
        <button class="btn btn-primary" (click)="openForm(null)">
          <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5">
            <line x1="12" y1="5" x2="12" y2="19"/><line x1="5" y1="12" x2="19" y2="12"/>
          </svg>
          Add Device
        </button>
      </div>

      <!-- Search -->
      <div class="card" style="margin-bottom:16px; padding:16px">
        <div class="search-bar">
          <input class="search-input" type="text" [(ngModel)]="searchQuery"
            placeholder="Search by name, manufacturer, processor, RAM..."
            (keyup.enter)="search()">
          <button class="btn btn-primary" (click)="search()" [disabled]="searching">
            <span *ngIf="searching" class="spinner" style="width:14px;height:14px;border-width:1.5px"></span>
            Search
          </button>
          <button class="btn btn-secondary" (click)="clearSearch()" *ngIf="isSearchMode">
            Clear
          </button>
        </div>
      </div>

      <!-- Alert -->
      <div *ngIf="successMsg" class="alert alert-success">{{ successMsg }}</div>
      <div *ngIf="errorMsg" class="alert alert-error">{{ errorMsg }}</div>

      <!-- Table -->
      <div class="card">
        <div *ngIf="loading" class="loading-state">
          <div class="spinner"></div> Loading devices...
        </div>

        <div *ngIf="!loading && displayedDevices.length === 0" class="empty-state">
          <svg width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="var(--gray-300)" stroke-width="1.5">
            <rect x="5" y="2" width="14" height="20" rx="2"/>
            <line x1="12" y1="18" x2="12" y2="18.01" stroke-width="2"/>
          </svg>
          <h3>No devices found</h3>
          <p>{{ isSearchMode ? 'Try a different search term.' : 'Add your first device to get started.' }}</p>
        </div>

        <table class="table" *ngIf="!loading && displayedDevices.length > 0">
          <thead>
            <tr>
              <th>Device</th>
              <th>Type</th>
              <th>OS</th>
              <th>Specs</th>
              <th>Assigned To</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let device of displayedDevices" (click)="viewDevice(device)">
              <td>
                <div style="font-weight:600; color:var(--gray-900)">{{ device.name }}</div>
                <div style="color:var(--gray-500); font-size:12px">{{ device.manufacturer }}</div>
              </td>
              <td>
                <span class="badge" [class.badge-phone]="device.type === 'phone'" [class.badge-tablet]="device.type === 'tablet'">
                  {{ device.type === 'phone' ? '📱' : '📋' }} {{ device.type }}
                </span>
              </td>
              <td>{{ device.operatingSystem }} {{ device.osVersion }}</td>
              <td>
                <div style="font-size:12px; color:var(--gray-600)">{{ device.processor }}</div>
                <div style="font-size:12px; color:var(--gray-500)">{{ device.ramAmount }} RAM</div>
              </td>
              <td (click)="$event.stopPropagation()">
                <span *ngIf="device.assignedToUserName" class="badge badge-assigned">{{ device.assignedToUserName }}</span>
                <span *ngIf="!device.assignedToUserName" class="badge badge-free">Available</span>
              </td>
              <td (click)="$event.stopPropagation()">
                <div style="display:flex; gap:6px">
                  <button class="btn btn-secondary btn-sm" (click)="openForm(device)" title="Edit">✏️</button>
                  <button class="btn btn-danger btn-sm" (click)="confirmDelete(device)" title="Delete">🗑️</button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- Device Form Modal -->
    <app-device-form *ngIf="showForm" [device]="editingDevice"
      (saved)="onDeviceSaved($event)" (cancelled)="closeForm()">
    </app-device-form>

    <!-- Delete Confirm Modal -->
    <div class="modal-overlay" *ngIf="deletingDevice" (click)="deletingDevice = null">
      <div class="modal" style="max-width:400px" (click)="$event.stopPropagation()">
        <div class="modal-header">
          <h2>Delete Device</h2>
          <button class="close-btn" (click)="deletingDevice = null">&#x2715;</button>
        </div>
        <div class="modal-body">
          <p>Are you sure you want to delete <strong>{{ deletingDevice.name }}</strong>? This action cannot be undone.</p>
        </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" (click)="deletingDevice = null">Cancel</button>
          <button class="btn btn-danger" (click)="deleteDevice()" [disabled]="deleting">
            <span *ngIf="deleting" class="spinner"></span>
            {{ deleting ? 'Deleting...' : 'Delete' }}
          </button>
        </div>
      </div>
    </div>
  `
})

export class DeviceListComponent implements OnInit {
    devices: Device[] = [];
    displayedDevices: Device[] = [];
    loading = true;
    searching = false;
    isSearchMode = false;
    showForm = false;
    editingDevice: Device | null = null;
    deletingDevice: Device | null = null;
    deleting = false;
    searchQuery: string = '';
    successMsg: string = '';
    errorMsg: string = '';

    constructor(
        private deviceService: DeviceService,
        private authService: AuthService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.loadDevices();
    }

    loadDevices(): void {
        this.loading = true;
        this.deviceService.getAll().subscribe({
            next: (data) => {
                this.devices = data;
                this.displayedDevices = data;
                this.loading = false;
            },
            error: () => {
                this.errorMsg = 'Failed to load devices.';
                this.loading = false;
            }
        });
    }

    search(): void {
        if (!this.searchQuery.trim()) {
            this.clearSearch();
            return;
        }
        this.searching = true;
        this.isSearchMode = true;
        this.deviceService.search(this.searchQuery).subscribe({
            next: (data) => {
                this.displayedDevices = data;
                this.searching = false;
            },
            error: () => {
                this.searching = false;
            }
        });
    }

    clearSearch(): void {
        this.searchQuery = '';
        this.isSearchMode = false;
        this.displayedDevices = this.devices;
    }

    viewDevice(device: Device): void {
        this.router.navigate(['/devices', device.id]);
    }

    openForm(device: Device | null): void {
        this.editingDevice = device;
        this.showForm = true;
        this.errorMsg = '';
    }

    closeForm(): void {
        this.showForm = false;
        this.editingDevice = null;
    }

    onDeviceSaved(device: Device): void {
        this.closeForm();
        this.loadDevices();
        this.showSuccess(this.editingDevice ? 'Device updated.' : 'Device created.');
    }

    confirmDelete(device: Device): void {
        this.deletingDevice = device;
    }

    deleteDevice(): void {
        if (!this.deletingDevice) return;
        this.deleting = true;
        this.deviceService.delete(this.deletingDevice.id).subscribe({
            next: () => {
                this.deleting = false;
                this.deletingDevice = null;
                this.loadDevices();
                this.showSuccess('Device deleted successfully.');
            },
            error: () => {
                this.deleting = false;
                this.errorMsg = 'Failed to delete device.';
            }
        });
    }

    private showSuccess(msg: string): void {
        this.successMsg = msg;
        setTimeout(() => this.successMsg = '', 3000);
    }
}