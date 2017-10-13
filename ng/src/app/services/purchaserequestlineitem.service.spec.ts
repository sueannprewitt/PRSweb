import { TestBed, inject } from '@angular/core/testing';

import { PurchaserequestlineitemService } from './purchaserequestlineitem.service';

describe('PurchaserequestlineitemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PurchaserequestlineitemService]
    });
  });

  it('should be created', inject([PurchaserequestlineitemService], (service: PurchaserequestlineitemService) => {
    expect(service).toBeTruthy();
  }));
});
