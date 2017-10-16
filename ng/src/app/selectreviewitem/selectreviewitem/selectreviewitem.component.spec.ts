import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectreviewitemComponent } from './selectreviewitem.component';

describe('SelectreviewitemComponent', () => {
  let component: SelectreviewitemComponent;
  let fixture: ComponentFixture<SelectreviewitemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectreviewitemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectreviewitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
