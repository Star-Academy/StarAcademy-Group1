import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EdgesViewPanelComponent } from './edges-view-panel.component';

describe('EdgesViewPanelComponent', () => {
  let component: EdgesViewPanelComponent;
  let fixture: ComponentFixture<EdgesViewPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdgesViewPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdgesViewPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
