import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

export interface PaymentFine {
  fineRef: string;
  vehicleNumber: string;
  offenseDate: string;
  amount: number;
  paymentStatus: 'Paid' | 'Pending' | 'Manual';
  paymentMethod: string;
  paymentDate: string;
}

@Injectable({
  providedIn: 'root'
})
export class MockPaymentFinesServiceService {

  private fines: PaymentFine[] = [
    { fineRef: 'F-1001', vehicleNumber: 'WP-AB-1234', offenseDate: '2024-07-10', amount: 1500, paymentStatus: 'Paid', paymentMethod: 'GovPay', paymentDate: '2024-07-11' },
    { fineRef: 'F-1002', vehicleNumber: 'WP-CD-5678', offenseDate: '2024-07-11', amount: 2000, paymentStatus: 'Pending', paymentMethod: '-', paymentDate: '-' },
    { fineRef: 'F-1003', vehicleNumber: 'CP-XY-1122', offenseDate: '2024-07-12', amount: 1200, paymentStatus: 'Paid', paymentMethod: 'GovPay', paymentDate: '2024-07-13' },
    { fineRef: 'F-1004', vehicleNumber: 'SP-ZZ-3344', offenseDate: '2024-07-13', amount: 1800, paymentStatus: 'Paid', paymentMethod: 'Manual', paymentDate: '2024-07-14' },
    { fineRef: 'F-1005', vehicleNumber: 'WP-KL-7788', offenseDate: '2024-07-14', amount: 2500, paymentStatus: 'Pending', paymentMethod: '-', paymentDate: '-' },
    { fineRef: 'F-1006', vehicleNumber: 'NP-MM-9900', offenseDate: '2024-07-15', amount: 1600, paymentStatus: 'Pending', paymentMethod: '-', paymentDate: '-' },
    { fineRef: 'F-1007', vehicleNumber: 'EP-QQ-4455', offenseDate: '2024-07-16', amount: 1400, paymentStatus: 'Paid', paymentMethod: 'GovPay', paymentDate: '2024-07-17' },
    { fineRef: 'F-1008', vehicleNumber: 'WP-TT-6677', offenseDate: '2024-07-17', amount: 3000, paymentStatus: 'Paid', paymentMethod: 'GovPay', paymentDate: '2024-07-16' },
    { fineRef: 'F-1009', vehicleNumber: 'CP-UU-8899', offenseDate: '2024-07-18', amount: 1100, paymentStatus: 'Paid', paymentMethod: 'GovPay', paymentDate: '2024-07-19' },
    { fineRef: 'F-1010', vehicleNumber: 'SP-VV-1010', offenseDate: '2024-07-19', amount: 2200, paymentStatus: 'Paid', paymentMethod: 'Manual', paymentDate: '2024-07-20' }
  ];

  getAll(): Observable<PaymentFine[]> {
    return of(this.fines);
  }
}
