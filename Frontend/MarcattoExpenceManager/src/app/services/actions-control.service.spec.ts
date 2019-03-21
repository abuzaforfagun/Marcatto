import { TestBed } from '@angular/core/testing';

import { ActionsControlService } from './actions-control.service';

describe('ActionsControlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ActionsControlService = TestBed.get(ActionsControlService);
    expect(service).toBeTruthy();
  });
});
