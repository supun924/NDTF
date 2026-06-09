import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

export interface DrivingLicense {
  driverName: string;
  dlNumber: string;
  dateCollected: string;
  violationRef: string;
  returnDue: string;
  status: 'Held' | 'Returned' | 'Expired';
}

@Injectable({
  providedIn: 'root'
})
export class MockDrivingLicenseServiceService {

  private licenses: DrivingLicense[] = [
    { driverName: 'Nimal Perera', dlNumber: 'DL-SL-1001', dateCollected: '2024-07-01', violationRef: 'V-1001', returnDue: '2024-08-01', status: 'Held' },
    { driverName: 'Kavindu Fernando', dlNumber: 'DL-SL-1002', dateCollected: '2024-07-02', violationRef: 'V-1002', returnDue: '2024-08-02', status: 'Returned' },
    { driverName: 'Tharushi Jayasinghe', dlNumber: 'DL-SL-1003', dateCollected: '2024-07-03', violationRef: 'V-1003', returnDue: '2024-08-03', status: 'Held' },
    { driverName: 'Lahiru Bandara', dlNumber: 'DL-SL-1004', dateCollected: '2024-07-04', violationRef: 'V-1004', returnDue: '2024-08-04', status: 'Returned' },
    { driverName: 'Pasindu Silva', dlNumber: 'DL-SL-1005', dateCollected: '2024-07-05', violationRef: 'V-1005', returnDue: '2024-08-05', status: 'Held' },
    { driverName: 'Dinuka Herath', dlNumber: 'DL-SL-1006', dateCollected: '2024-07-06', violationRef: 'V-1006', returnDue: '2024-08-06', status: 'Expired' },
    { driverName: 'Sanduni Perera', dlNumber: 'DL-SL-1007', dateCollected: '2024-07-07', violationRef: 'V-1007', returnDue: '2024-08-07', status: 'Returned' },
    { driverName: 'Hasitha Wijesinghe', dlNumber: 'DL-SL-1008', dateCollected: '2024-07-08', violationRef: 'V-1008', returnDue: '2024-08-08', status: 'Held' },
    { driverName: 'Irosha Madushani', dlNumber: 'DL-SL-1009', dateCollected: '2024-07-09', violationRef: 'V-1009', returnDue: '2024-08-09', status: 'Returned' },
    { driverName: 'Udara Kumara', dlNumber: 'DL-SL-1010', dateCollected: '2024-07-10', violationRef: 'V-1010', returnDue: '2024-08-10', status: 'Held' }
  ];

  getAll(): Observable<DrivingLicense[]> {
    return of(this.licenses);
  }
}
