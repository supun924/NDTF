import { Component } from '@angular/core';
import { DrivingLicense, MockDrivingLicenseServiceService } from 'src/app/core/services/mock-driving-license.service.service';

@Component({
  selector: 'app-driving-license',
  templateUrl: './driving-license.component.html',
  styleUrls: ['./driving-license.component.css']
})
export class DrivingLicenseComponent {
  
  licenses: DrivingLicense[] = [];

  constructor(private service: MockDrivingLicenseServiceService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.service.getAll().subscribe(data => {
      this.licenses = data;
    });
  }
}
