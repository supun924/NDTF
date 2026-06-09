import { TestBed } from '@angular/core/testing';

import { MockTrafficFinesServiceService } from './mock-traffic-fines.service.service';

describe('MockTrafficFinesServiceService', () => {
  let service: MockTrafficFinesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MockTrafficFinesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
