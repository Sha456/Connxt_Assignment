import { TestBed } from '@angular/core/testing';

import { ValidateCreditCardServiceService } from './validate-credit-card-service.service';

describe('ValidateCreditCardServiceService', () => {
  let service: ValidateCreditCardServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ValidateCreditCardServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
