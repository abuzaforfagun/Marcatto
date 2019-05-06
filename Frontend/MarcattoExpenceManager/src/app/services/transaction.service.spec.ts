import { TransactionService } from 'src/app/services/transaction.service';
import { TestBed } from '@angular/core/testing';


describe('IncomeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TransactionService = TestBed.get(TransactionService);
    expect(service).toBeTruthy();
  });
});
