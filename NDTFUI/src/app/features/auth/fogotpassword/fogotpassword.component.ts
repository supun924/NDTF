import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fogotpassword',
  templateUrl: './fogotpassword.component.html',
  styleUrls: ['./fogotpassword.component.css']
})
export class FogotpasswordComponent implements OnInit {

  forgotForm!: FormGroup;

  message = '';

  loading = false;

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.forgotForm =
      this.fb.group({

        username: [
          '',
          Validators.required
        ]

      });

  }

  submit(): void {

    if (this.forgotForm.invalid) {

      this.message =
        'Please enter Officer ID or Email';

      return;

    }

    this.loading = true;

    setTimeout(() => {

      this.loading = false;

      this.message =
        'Password reset instructions have been sent.';

    }, 1500);

  }

  openBackLogin(): void {
    this.router.navigate(['/auth/login']);
  }

}
