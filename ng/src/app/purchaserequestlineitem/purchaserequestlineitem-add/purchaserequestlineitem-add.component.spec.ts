import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestlineitemAddComponent } from './purchaserequestlineitem-add.component';

describe('PurchaserequestlineitemAddComponent', () => {
  let component: PurchaserequestlineitemAddComponent;
  let fixture: ComponentFixture<PurchaserequestlineitemAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestlineitemAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestlineitemAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
