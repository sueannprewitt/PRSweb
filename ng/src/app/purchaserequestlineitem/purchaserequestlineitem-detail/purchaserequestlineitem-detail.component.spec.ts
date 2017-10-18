import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestlineitemDetailComponent } from './purchaserequestlineitem-detail.component';

describe('PurchaserequestlineitemDetailComponent', () => {
  let component: PurchaserequestlineitemDetailComponent;
  let fixture: ComponentFixture<PurchaserequestlineitemDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestlineitemDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestlineitemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
