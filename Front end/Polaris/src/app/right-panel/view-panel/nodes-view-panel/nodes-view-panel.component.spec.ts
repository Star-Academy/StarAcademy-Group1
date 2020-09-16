import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NodesViewPanelComponent } from './nodes-view-panel.component';

describe('NodesViewPanelComponent', () => {
  let component: NodesViewPanelComponent;
  let fixture: ComponentFixture<NodesViewPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NodesViewPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NodesViewPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
