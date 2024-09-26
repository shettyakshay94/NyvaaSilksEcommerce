import { TestBed } from '@angular/core/testing';

import { AdminLibraryService } from './admin-library.service';

describe('AdminLibraryService', () => {
  let service: AdminLibraryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminLibraryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
