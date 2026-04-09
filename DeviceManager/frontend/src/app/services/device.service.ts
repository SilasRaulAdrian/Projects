import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateDeviceDto, Device, GenerateDescriptionDto, UpdateDeviceDto } from '../models/models';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DeviceService {
    private apiUrl = `${environment.apiUrl}/devices`;

    constructor(private http: HttpClient) {}

    getAll(): Observable<Device[]> {
        return this.http.get<Device[]>(this.apiUrl);
    }

    getById(id: number): Observable<Device> {
        return this.http.get<Device>(`${this.apiUrl}/${id}`);
    }

    create(dto: CreateDeviceDto): Observable<Device> {
        return this.http.post<Device>(this.apiUrl, dto);
    }

    update(id: number, dto: UpdateDeviceDto): Observable<Device> {
        return this.http.put<Device>(`${this.apiUrl}/${id}`, dto);
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }

    assign(deviceId: number): Observable<Device> {
        return this.http.post<Device>(`${this.apiUrl}/${deviceId}/assign`, {});
    }

    unassign(deviceId: number): Observable<Device> {
        return this.http.post<Device>(`${this.apiUrl}/${deviceId}/unassign`, {});
    }

    search(query: string): Observable<Device[]> {
        const params = new HttpParams().set('q', query);
        return this.http.get<Device[]>(`${this.apiUrl}/search`, { params });
    }

    generateDescription(dto: GenerateDescriptionDto): Observable<{ description: string }> {
        return this.http.post<{ description: string }>(`${this.apiUrl}/generate-description`, dto);
    }
}