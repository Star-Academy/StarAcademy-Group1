import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchFilterComponent } from './branch-filter.component';

describe('BranchFilterComponent', () => {
  let component: BranchFilterComponent;
  let fixture: ComponentFixture<BranchFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
