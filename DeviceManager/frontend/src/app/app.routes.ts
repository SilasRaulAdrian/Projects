import { Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: '/devices',
        pathMatch: 'full'
    },
    {
        path: 'login',
        loadComponent: () => import('./components/login/login.component').then(m => m.LoginComponent)
    },
    {
        path: 'register',
        loadComponent: () => import('./components/register/register.component').then(m => m.RegisterComponent)
    },
    {
        path: 'devices',
        loadComponent: () => import('./components/device-list/device-list.component').then(m => m.DeviceListComponent),
        canActivate: [authGuard]
    },
    {
        path: 'devices/:id',
        loadComponent: () => import('./components/device-detail/device-detail.component').then(m => m.DeviceDetailComponent),
        canActivate: [authGuard]
    }
];
