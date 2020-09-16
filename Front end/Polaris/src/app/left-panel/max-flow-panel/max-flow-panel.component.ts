import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-max-flow-panel',
  templateUrl: './max-flow-panel.component.html',
  styleUrls: ['./max-flow-panel.component.scss']
})
export class MaxFlowPanelComponent implements OnInit {
  
  MaxFlowFilters = [true, true, true, true, true]; // Account, Amount, Branch, Name, Time

  constructor() { }

  ngOnInit(): void {
  }

}
