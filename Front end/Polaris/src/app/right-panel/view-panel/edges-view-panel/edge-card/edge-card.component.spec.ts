import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EdgeCardComponent } from './edge-card.component';

describe('EdgeCardComponent', () => {
  let component: EdgeCardComponent;
  let fixture: ComponentFixture<EdgeCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdgeCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdgeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
