import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RealTimeSearchBarComponent } from './real-time-search-bar.component';

describe('RealTimeSearchBarComponent', () => {
  let component: RealTimeSearchBarComponent;
  let fixture: ComponentFixture<RealTimeSearchBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RealTimeSearchBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RealTimeSearchBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
