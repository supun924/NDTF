export interface User {
  username: string;
  password: string;
  role: 'ADMIN' | 'OFFICER';
}

export interface LoginResponse {
  success: boolean;
  message: string;
  data?: {
    username: string;
    role: 'ADMIN' | 'OFFICER';
    token: string;
  };
}