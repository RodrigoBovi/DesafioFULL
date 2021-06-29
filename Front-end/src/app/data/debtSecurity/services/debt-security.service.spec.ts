import { TestBed } from '@angular/core/testing';

import { DebtSecurityService } from './debt-security.service';

describe('DebtSecurityService', () => {
  let service: DebtSecurityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DebtSecurityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
