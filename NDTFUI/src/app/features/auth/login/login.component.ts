import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MockAuthService } from '../../../core/services/mock-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  message: string = '';
  loading = false;

  // ✅ ADD THIS
  showPassword: boolean = false;

  constructor(
    private fb: FormBuilder,
    private authService: MockAuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // ✅ ADD THIS
  togglePassword(): void {
    this.showPassword = !this.showPassword;
  }

  onLogin(): void {
    if (this.loginForm.invalid) {
      this.message = 'Please enter username and password';
      return;
    }

    this.loading = true;
    this.message = '';

    const { username, password } = this.loginForm.value;

    this.authService.login(username, password).subscribe({
      next: (result: any) => {

        this.loading = false;

        if (result?.success && result?.data) {
          this.message = `Welcome ${result.data.username} (${result.data.role})`;

          localStorage.setItem('token', result.data.token);

          this.router.navigate(['/dashboard/dashboard-home']);
        } else {
          this.message = result?.message || 'Login failed';
        }
      },

      error: () => {
        this.loading = false;
        this.message = 'Server error. Try again.';
      }
    });
  }

  openForgotPassword(): void {
    this.router.navigate(['/auth/fogotpassword']);
  }
}