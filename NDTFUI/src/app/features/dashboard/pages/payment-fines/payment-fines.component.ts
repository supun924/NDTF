import { Component } from '@angular/core';
import { MockPaymentFinesServiceService, PaymentFine } from 'src/app/core/services/mock-payment-fines.service.service';

@Component({
  selector: 'app-payment-fines',
  templateUrl: './payment-fines.component.html',
  styleUrls: ['./payment-fines.component.css']
})
export class PaymentFinesComponent {
  fines: PaymentFine[] = [];

  constructor(private service: MockPaymentFinesServiceService) { }

  ngOnInit(): void {
    this.loadFines();
  }

  loadFines() {
    this.service.getAll().subscribe(data => {
      this.fines = data;
    });
  }
}
