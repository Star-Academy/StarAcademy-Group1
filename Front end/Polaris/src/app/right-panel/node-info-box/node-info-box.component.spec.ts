import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NodeInfoBoxComponent } from './node-info-box.component';

describe('NodeInfoBoxComponent', () => {
  let component: NodeInfoBoxComponent;
  let fixture: ComponentFixture<NodeInfoBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NodeInfoBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NodeInfoBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
