import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EdgeInfoBoxComponent } from './edge-info-box.component';

describe('EdgeInfoBoxComponent', () => {
  let component: EdgeInfoBoxComponent;
  let fixture: ComponentFixture<EdgeInfoBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdgeInfoBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdgeInfoBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
