import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

export interface TrafficFine {
  driverName: string;
  dlNumber: string;
  vehicleNumber: string;
  violation: string;
  amount: number;
  status: 'Paid' | 'Pending' | 'Manual';
  dateIssued: string;
}

export interface FineSummary {
  total: number;
  paid: number;
  pending: number;
  manual: number;
}

@Injectable({
  providedIn: 'root'
})
export class MockTrafficFinesServiceService {

  private fines: TrafficFine[] = [
    { driverName: 'Nimal Perera', dlNumber: 'DL-SL-1001', vehicleNumber: 'WP-AB-1234', violation: 'Speeding', amount: 1500, status: 'Paid', dateIssued: '2024-07-10' },
    { driverName: 'Kavindu Fernando', dlNumber: 'DL-SL-1002', vehicleNumber: 'WP-CD-5678', violation: 'Signal Jump', amount: 2000, status: 'Pending', dateIssued: '2024-07-11' },
    { driverName: 'Tharushi Jayasinghe', dlNumber: 'DL-SL-1003', vehicleNumber: 'CP-XY-1122', violation: 'No Helmet', amount: 1200, status: 'Paid', dateIssued: '2024-07-12' },
    { driverName: 'Lahiru Bandara', dlNumber: 'DL-SL-1004', vehicleNumber: 'SP-ZZ-3344', violation: 'Drunk Driving', amount: 5000, status: 'Pending', dateIssued: '2024-07-13' },
    { driverName: 'Pasindu Silva', dlNumber: 'DL-SL-1005', vehicleNumber: 'WP-KL-7788', violation: 'Speeding', amount: 1800, status: 'Paid', dateIssued: '2024-07-14' },
    { driverName: 'Dinuka Herath', dlNumber: 'DL-SL-1006', vehicleNumber: 'NP-MM-9900', violation: 'Wrong Parking', amount: 1000, status: 'Manual', dateIssued: '2024-07-15' },
    { driverName: 'Sanduni Perera', dlNumber: 'DL-SL-1007', vehicleNumber: 'EP-QQ-4455', violation: 'Signal Jump', amount: 1600, status: 'Paid', dateIssued: '2024-07-16' },
    { driverName: 'Hasitha Wijesinghe', dlNumber: 'DL-SL-1008', vehicleNumber: 'WP-TT-6677', violation: 'Speeding', amount: 2000, status: 'Pending', dateIssued: '2024-07-17' },
    { driverName: 'Irosha Madushani', dlNumber: 'DL-SL-1009', vehicleNumber: 'CP-UU-8899', violation: 'No Seatbelt', amount: 1100, status: 'Paid', dateIssued: '2024-07-18' },
    { driverName: 'Udara Kumara', dlNumber: 'DL-SL-1010', vehicleNumber: 'SP-VV-1010', violation: 'Over Speed', amount: 2200, status: 'Manual', dateIssued: '2024-07-19' }
  ];

  getFines(): Observable<TrafficFine[]> {
    return of(this.fines);
  }

  getSummary(): Observable<FineSummary> {
    const summary: FineSummary = {
      total: this.fines.length,
      paid: this.fines.filter(f => f.status === 'Paid').length,
      pending: this.fines.filter(f => f.status === 'Pending').length,
      manual: this.fines.filter(f => f.status === 'Manual').length
    };

    return of(summary);
  }
}
