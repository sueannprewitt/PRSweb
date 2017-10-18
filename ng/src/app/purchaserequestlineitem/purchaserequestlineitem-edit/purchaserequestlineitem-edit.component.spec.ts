import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestlineitemEditComponent } from './purchaserequestlineitem-edit.component';

describe('PurchaserequestlineitemEditComponent', () => {
  let component: PurchaserequestlineitemEditComponent;
  let fixture: ComponentFixture<PurchaserequestlineitemEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestlineitemEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestlineitemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
