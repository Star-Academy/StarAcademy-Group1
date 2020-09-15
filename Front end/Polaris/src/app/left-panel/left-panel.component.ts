import {ChangeDetectorRef, Component, Input, OnDestroy} from '@angular/core';


/** @title Responsive sidenav */
@Component({
  selector: 'app-left-panel',
  templateUrl: 'left-panel.component.html',
  styleUrls: ['left-panel.component.scss'],
})
export class LeftPanelComponent implements OnDestroy {
@Input()
public info:string
  constructor() {
  }

  ngOnDestroy(): void {
  }
}
