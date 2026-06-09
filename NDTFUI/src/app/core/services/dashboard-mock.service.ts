import { Injectable } from '@angular/core';
import { DashboardData } from 'src/app/models/dashboard.model';


@Injectable({
  providedIn: 'root'
})
export class DashboardMockService {

  getDashboard(): DashboardData {
    return {
      totalFines: 10,
      totalAmount: 1240.00,
      shiftSeconds: 24135,
      records: [
        { id: 'CN-001', name: 'Nimal Perera', violation: 'Excessive Speed (20+ over limit)', status: 'Paid' },
        { id: 'CN-002', name: 'Kavindu Fernando', violation: 'Running Red Light', status: 'Unpaid' },
        { id: 'CN-003', name: 'Tharushi Jayasinghe', violation: 'Expired Registration', status: 'Paid' },
        { id: 'CN-004', name: 'Lahiru Bandara', violation: 'Excessive Speed (20+ over limit)', status: 'Paid' },
        { id: 'CN-005', name: 'Pasindu Silva', violation: 'Running Red Light', status: 'Unpaid' },
        { id: 'CN-006', name: 'Dinuka Herath', violation: 'Expired Registration', status: 'Paid' },
        { id: 'CN-007', name: 'Sanduni Perera', violation: 'Excessive Speed (20+ over limit)', status: 'Paid' },
        { id: 'CN-008', name: 'Hasitha Wijesinghe', violation: 'Running Red Light', status: 'Unpaid' },
        { id: 'CN-009', name: 'Irosha Madushani', violation: 'Expired Registration', status: 'Paid' },
        { id: 'CN-010', name: 'Udara Kumara', violation: 'Expired Registration', status: 'Paid' }
      ]
    };
  }
}