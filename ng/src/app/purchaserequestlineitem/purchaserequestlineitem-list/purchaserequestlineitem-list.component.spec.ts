import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestlineitemListComponent } from './purchaserequestlineitem-list.component';

describe('PurchaserequestlineitemListComponent', () => {
  let component: PurchaserequestlineitemListComponent;
  let fixture: ComponentFixture<PurchaserequestlineitemListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestlineitemListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestlineitemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
