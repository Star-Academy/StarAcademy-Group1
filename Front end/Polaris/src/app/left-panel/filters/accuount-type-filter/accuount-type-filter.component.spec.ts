import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccuountTypeComponent } from './accuount-type-filter.component';

describe('AccuountTypeComponent', () => {
  let component: AccuountTypeComponent;
  let fixture: ComponentFixture<AccuountTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AccuountTypeComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccuountTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
