import { Component, OnDestroy, OnInit } from '@angular/core';
import { DashboardMockService } from 'src/app/core/services/dashboard-mock.service';
import { DashboardData, DashboardRecord } from 'src/app/models/dashboard.model';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.css']
})
export class DashboardHomeComponent implements  OnInit, OnDestroy{
  data!: DashboardData;

  currentDate = new Date().toDateString();
  pendingSync = 3;

  interval: any;

  constructor(private dashboardService: DashboardMockService) { }

  ngOnInit() {
    this.data = this.dashboardService.getDashboard();
    this.startTimer();
  }

  get shiftTime(): string {
    const h = Math.floor(this.data.shiftSeconds / 3600);
    const m = Math.floor((this.data.shiftSeconds % 3600) / 60);
    const s = this.data.shiftSeconds % 60;

    return `${h.toString().padStart(2, '0')}:` +
      `${m.toString().padStart(2, '0')}:` +
      `${s.toString().padStart(2, '0')}`;
  }

  startTimer() {
    this.interval = setInterval(() => {
      this.data.shiftSeconds++;
    }, 1000);
  }

  newCitation() {
    console.log('New Citation clicked');
  }

  openMenu(fine: any) {
    console.log(fine);
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }
}
