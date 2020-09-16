import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EdgCardComponent } from './edg-card.component';

describe('EdgCardComponent', () => {
  let component: EdgCardComponent;
  let fixture: ComponentFixture<EdgCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdgCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdgCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
