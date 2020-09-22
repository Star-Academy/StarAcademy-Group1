import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultPathsComponent } from './result-paths.component';

describe('ResultPathsComponent', () => {
  let component: ResultPathsComponent;
  let fixture: ComponentFixture<ResultPathsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultPathsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultPathsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
