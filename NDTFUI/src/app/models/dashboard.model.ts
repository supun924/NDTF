export interface DashboardRecord {
  id: string;
  name: string;
  violation?: string;
  status: 'Paid' | 'Unpaid';
}

export interface DashboardData {
  totalFines: number;
  totalAmount: number;
  shiftSeconds: number;
  records: DashboardRecord[];
}