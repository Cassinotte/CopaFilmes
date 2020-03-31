import { TestBed } from '@angular/core/testing';

import { Filme.ServiceService } from './filme.service.service';

describe('Filme.ServiceService', () => {
  let service: Filme.ServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Filme.ServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
