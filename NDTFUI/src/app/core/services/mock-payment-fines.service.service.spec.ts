import { TestBed } from '@angular/core/testing';

import { MockPaymentFinesServiceService } from './mock-payment-fines.service.service';

describe('MockPaymentFinesServiceService', () => {
  let service: MockPaymentFinesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MockPaymentFinesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
