import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNodePanelComponent } from './add-node-panel.component';

describe('AddNodePanelComponent', () => {
  let component: AddNodePanelComponent;
  let fixture: ComponentFixture<AddNodePanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNodePanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNodePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
