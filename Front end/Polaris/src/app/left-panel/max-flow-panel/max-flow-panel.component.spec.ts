import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaxFlowPanelComponent } from './max-flow-panel.component';

describe('MaxFlowPanelComponent', () => {
  let component: MaxFlowPanelComponent;
  let fixture: ComponentFixture<MaxFlowPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaxFlowPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaxFlowPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
