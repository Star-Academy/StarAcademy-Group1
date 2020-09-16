import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelsMenuComponent } from './panels-menu.component';

describe('PanelsMenuComponent', () => {
  let component: PanelsMenuComponent;
  let fixture: ComponentFixture<PanelsMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PanelsMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PanelsMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
