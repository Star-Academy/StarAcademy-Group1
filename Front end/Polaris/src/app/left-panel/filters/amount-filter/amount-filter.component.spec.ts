import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmountFilterComponent } from './amount-filter.component';

describe('AmountFilterComponent', () => {
  let component: AmountFilterComponent;
  let fixture: ComponentFixture<AmountFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AmountFilterComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmountFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
