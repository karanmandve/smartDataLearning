import { TestBed } from '@angular/core/testing';

import { AgentServiceService } from './patient-service.service';

describe('AgentServiceService', () => {
  let service: AgentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
