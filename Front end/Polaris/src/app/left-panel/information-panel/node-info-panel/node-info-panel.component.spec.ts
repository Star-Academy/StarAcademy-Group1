import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NodeInfoPanelComponent } from './node-info-panel.component';

describe('NodeInfoPanelComponent', () => {
  let component: NodeInfoPanelComponent;
  let fixture: ComponentFixture<NodeInfoPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NodeInfoPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NodeInfoPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
