import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphInfoBoxComponent } from './graph-info-box.component';

describe('GraphInfoBoxComponent', () => {
  let component: GraphInfoBoxComponent;
  let fixture: ComponentFixture<GraphInfoBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GraphInfoBoxComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraphInfoBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
