import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrafficFinesComponent } from './traffic-fines.component';

describe('TrafficFinesComponent', () => {
  let component: TrafficFinesComponent;
  let fixture: ComponentFixture<TrafficFinesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrafficFinesComponent]
    });
    fixture = TestBed.createComponent(TrafficFinesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
