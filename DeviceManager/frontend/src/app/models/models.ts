export interface Device {
  id: number;
  name: string;
  manufacturer: string;
  type: 'phone' | 'tablet';
  operatingSystem: string;
  osVersion: string;
  processor: string;
  ramAmount: string;
  description?: string;
  assignedToUserId?: number;
  assignedToUserName?: string;
  createdAt: string;
  updatedAt: string;
}

export interface CreateDeviceDto {
  name: string;
  manufacturer: string;
  type: string;
  operatingSystem: string;
  osVersion: string;
  processor: string;
  ramAmount: string;
  description?: string;
}

export interface UpdateDeviceDto extends CreateDeviceDto {}

export interface User {
  id: number;
  name: string;
  email: string;
  role: string;
  location: string;
}

export interface RegisterDto {
  name: string;
  email: string;
  password: string;
  role: string;
  location: string;
}

export interface LoginDto {
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  user: User;
}

export interface GenerateDescriptionDto {
  name: string;
  manufacturer: string;
  type: string;
  operatingSystem: string;
  osVersion: string;
  processor: string;
  ramAmount: string;
}
