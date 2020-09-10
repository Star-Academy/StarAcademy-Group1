import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphScreenComponent } from './graph-screen.component';

describe('GraphScreenComponent', () => {
  let component: GraphScreenComponent;
  let fixture: ComponentFixture<GraphScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GraphScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraphScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
