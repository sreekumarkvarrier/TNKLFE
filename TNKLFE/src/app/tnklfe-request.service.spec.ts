import { TestBed, inject } from '@angular/core/testing';

import { TnklfeRequestService } from './tnklfe-request.service';

describe('TnklfeRequestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TnklfeRequestService]
    });
  });

  it('should be created', inject([TnklfeRequestService], (service: TnklfeRequestService) => {
    expect(service).toBeTruthy();
  }));
});
