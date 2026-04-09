import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Device } from '../../models/models';
import { DeviceService } from '../../services/device.service';

@Component({
  selector: 'app-device-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="modal-overlay" (click)="onOverlayClick($event)">
      <div class="modal">
        <div class="modal-header">
          <h2>{{ device ? 'Edit Device' : 'Add New Device' }}</h2>
          <button class="close-btn" (click)="cancel()">&#x2715;</button>
        </div>

        <div class="modal-body">
          <div *ngIf="errorMsg" class="alert alert-error">{{ errorMsg }}</div>

          <form [formGroup]="form" id="deviceForm" (ngSubmit)="onSubmit()">
            <div class="form-grid">
              <div class="form-group">
                <label class="form-label">Device Name *</label>
                <input type="text" formControlName="name" class="form-control"
                  [class.is-invalid]="isInvalid('name')" placeholder="e.g. iPhone 15 Pro">
                <div *ngIf="isInvalid('name')" class="invalid-feedback">Name is required.</div>
              </div>
              <div class="form-group">
                <label class="form-label">Manufacturer *</label>
                <input type="text" formControlName="manufacturer" class="form-control"
                  [class.is-invalid]="isInvalid('manufacturer')" placeholder="e.g. Apple">
                <div *ngIf="isInvalid('manufacturer')" class="invalid-feedback">Manufacturer is required.</div>
              </div>
            </div>

            <div class="form-grid">
              <div class="form-group">
                <label class="form-label">Type *</label>
                <select formControlName="type" class="form-control" [class.is-invalid]="isInvalid('type')">
                  <option value="">Select type...</option>
                  <option value="phone">Phone</option>
                  <option value="tablet">Tablet</option>
                </select>
                <div *ngIf="isInvalid('type')" class="invalid-feedback">Type is required.</div>
              </div>
              <div class="form-group">
                <label class="form-label">Operating System *</label>
                <input type="text" formControlName="operatingSystem" class="form-control"
                  [class.is-invalid]="isInvalid('operatingSystem')" placeholder="e.g. iOS">
                <div *ngIf="isInvalid('operatingSystem')" class="invalid-feedback">OS is required.</div>
              </div>
            </div>

            <div class="form-grid">
              <div class="form-group">
                <label class="form-label">OS Version *</label>
                <input type="text" formControlName="osVersion" class="form-control"
                  [class.is-invalid]="isInvalid('osVersion')" placeholder="e.g. 17.4">
                <div *ngIf="isInvalid('osVersion')" class="invalid-feedback">OS version is required.</div>
              </div>
              <div class="form-group">
                <label class="form-label">RAM *</label>
                <input type="text" formControlName="ramAmount" class="form-control"
                  [class.is-invalid]="isInvalid('ramAmount')" placeholder="e.g. 8GB">
                <div *ngIf="isInvalid('ramAmount')" class="invalid-feedback">RAM is required.</div>
              </div>
            </div>

            <div class="form-group">
              <label class="form-label">Processor *</label>
              <input type="text" formControlName="processor" class="form-control"
                [class.is-invalid]="isInvalid('processor')" placeholder="e.g. A17 Pro">
              <div *ngIf="isInvalid('processor')" class="invalid-feedback">Processor is required.</div>
            </div>

            <div class="form-group">
              <div style="display:flex; align-items:center; justify-content:space-between; margin-bottom:6px">
                <label class="form-label" style="margin:0">Description</label>
                <button type="button" class="btn btn-secondary btn-sm" (click)="generateDescription()"
                  [disabled]="generatingDesc || form.get('name')?.invalid">
                  <span *ngIf="generatingDesc" class="spinner" style="width:12px;height:12px;border-width:1.5px"></span>
                  ✨ AI Generate
                </button>
              </div>
              <textarea formControlName="description" class="form-control" rows="3"
                placeholder="A brief description of the device..."></textarea>
            </div>
          </form>
        </div>

        <div class="modal-footer">
          <button class="btn btn-secondary" (click)="cancel()">Cancel</button>
          <button class="btn btn-primary" form="deviceForm" type="submit" [disabled]="loading">
            <span *ngIf="loading" class="spinner"></span>
            {{ loading ? 'Saving...' : (device ? 'Save Changes' : 'Add Device') }}
          </button>
        </div>
      </div>
    </div>
  `
})

export class DeviceFormComponent implements OnInit, OnChanges {
    @Input() device: Device | null = null;
    @Output() saved = new EventEmitter<Device>();
    @Output() cancelled = new EventEmitter<void>();

    form!: FormGroup;
    loading = false;
    generatingDesc = false;
    errorMsg: string = '';

    constructor(private fb: FormBuilder, private deviceService: DeviceService) {}

    ngOnInit(): void {
        this.buildForm();
    }

    ngOnChanges(): void {
        this.buildForm();
    }

    private buildForm(): void {
        this.form = this.fb.group({
            name: [this.device?.name ?? '', Validators.required],
            manufacturer: [this.device?.manufacturer ?? '', Validators.required],
            type: [this.device?.type ?? '', Validators.required],
            operatingSystem: [this.device?.operatingSystem ?? '', Validators.required],
            osVersion: [this.device?.osVersion ?? '', Validators.required],
            processor: [this.device?.processor ?? '', Validators.required],
            ramAmount: [this.device?.ramAmount ?? '', Validators.required],
            description: [this.device?.description ?? '']
        });
    }

    isInvalid(field: string): boolean {
        const ctrl = this.form.get(field);
        return !!(ctrl?.invalid && ctrl?.touched);
    }

    generateDescription(): void {
        this.form.markAllAsTouched();
        const v = this.form.value;
        if (!v.name || !v.manufacturer || !v.type || !v.operatingSystem || !v.osVersion || !v.processor || !v.ramAmount) return;

        this.generatingDesc = true;
        this.deviceService.generateDescription(v).subscribe({
            next: (res) => {
                this.form.patchValue({ description: res.description });
                this.generatingDesc = false;
            },
            error: () => {
                this.generatingDesc = false;
            }
        });
    }

    onSubmit(): void {
        if (this.form.invalid) { this.form.markAllAsTouched(); return; }
        this.loading = true;
        this.errorMsg = '';
        const dto = this.form.value;
        const request = this.device
            ? this.deviceService.update(this.device.id, dto)
            : this.deviceService.create(dto);

        request.subscribe({
            next: (device) => {
                this.loading = false;
                this.saved.emit(device);
            },
            error: (err) => {
                this.loading = false;
                this.errorMsg = err.status === 409 ? 'A device with this name already exists.' : 'Failed to save device.';
            }
        });
    }

    cancel(): void {
        this.cancelled.emit();
    }

    onOverlayClick(event: MouseEvent): void {
        if ((event.target as HTMLElement).classList.contains('modal-overlay')) {
            this.cancel();
        }
    }
}