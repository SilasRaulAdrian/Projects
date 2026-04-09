import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { AuthResponse, LoginDto, RegisterDto, User } from '../models/models';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private apiUrl = `${environment.apiUrl}/auth`;
    private currentUserSubject = new BehaviorSubject<User | null>(this.loadUser());
    currentUser$ = this.currentUserSubject.asObservable();

    constructor(private http: HttpClient) {}

    register(dto: RegisterDto): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/register`, dto).pipe(
            tap(res => this.saveSession(res))
        );
    }

    login(dto: LoginDto): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/login`, dto).pipe(
            tap(res => this.saveSession(res))
        );
    }

    logout() {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        this.currentUserSubject.next(null);
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    get currentUser(): User | null {
        return this.currentUserSubject.value;
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }

    private saveSession(res: AuthResponse) {
        localStorage.setItem('token', res.token);
        localStorage.setItem('user', JSON.stringify(res.user));
        this.currentUserSubject.next(res.user);
    }

    private loadUser(): User | null {
        const stored = localStorage.getItem('user');
        return stored ? JSON.parse(stored) : null;
    }
}