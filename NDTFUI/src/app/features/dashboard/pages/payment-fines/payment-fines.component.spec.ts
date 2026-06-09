import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentFinesComponent } from './payment-fines.component';

describe('PaymentFinesComponent', () => {
  let component: PaymentFinesComponent;
  let fixture: ComponentFixture<PaymentFinesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaymentFinesComponent]
    });
    fixture = TestBed.createComponent(PaymentFinesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
