import { TestBed } from '@angular/core/testing';

import { AuthorwithbooksService } from './authorwithbooks.service';

describe('AuthorwithbooksService', () => {
  let service: AuthorwithbooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthorwithbooksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
