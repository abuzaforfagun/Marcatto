import { TestBed } from '@angular/core/testing';

import { PaymentOptionsService } from './payment-options.service';

describe('PaymentOptionsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PaymentOptionsService = TestBed.get(PaymentOptionsService);
    expect(service).toBeTruthy();
  });
});
