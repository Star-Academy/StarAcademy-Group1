import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PathsPanelComponent } from './paths-panel.component';

describe('PathsPanelComponent', () => {
  let component: PathsPanelComponent;
  let fixture: ComponentFixture<PathsPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PathsPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PathsPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
