import { TestBed } from '@angular/core/testing';

import { MockDrivingLicenseServiceService } from './mock-driving-license.service.service';

describe('MockDrivingLicenseServiceService', () => {
  let service: MockDrivingLicenseServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MockDrivingLicenseServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
