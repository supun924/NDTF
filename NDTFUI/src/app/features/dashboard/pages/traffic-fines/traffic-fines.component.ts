import { Component } from '@angular/core';
import { FineSummary, MockTrafficFinesServiceService, TrafficFine } from 'src/app/core/services/mock-traffic-fines.service.service';

@Component({
  selector: 'app-traffic-fines',
  templateUrl: './traffic-fines.component.html',
  styleUrls: ['./traffic-fines.component.css']
})
export class TrafficFinesComponent {

  fines: TrafficFine[] = [];

  summary!: FineSummary;

  constructor(private service: MockTrafficFinesServiceService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.service.getFines().subscribe(data => {
      this.fines = data;
    });

    this.service.getSummary().subscribe(data => {
      this.summary = data;
    });
  }

  refresh() {
    this.loadData();
    console.log('Refresh fines');
  }

}
