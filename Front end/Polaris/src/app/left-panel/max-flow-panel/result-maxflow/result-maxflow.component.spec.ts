import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultMaxflowComponent } from './result-maxflow.component';

describe('ResultMaxflowComponent', () => {
  let component: ResultMaxflowComponent;
  let fixture: ComponentFixture<ResultMaxflowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultMaxflowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultMaxflowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
