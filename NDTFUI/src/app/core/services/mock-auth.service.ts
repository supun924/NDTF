import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { LoginResponse, User } from '../../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class MockAuthService {

  private users: User[] = [
    { username: 'admin', password: 'admin123', role: 'ADMIN' },
    { username: 'officer01', password: '1234', role: 'OFFICER' }
  ];

  login(username: string, password: string): Observable<LoginResponse> {

    const user = this.users.find(
      u => u.username === username && u.password === password
    );

    if (!user) {
      return of({
        success: false,
        message: 'Invalid username or password'
      });
    }

    return of({
      success: true,
      message: 'Login successful',
      data: {
        username: user.username,
        role: user.role,
        token: 'mock-token-' + Date.now()
      }
    });
  }
}