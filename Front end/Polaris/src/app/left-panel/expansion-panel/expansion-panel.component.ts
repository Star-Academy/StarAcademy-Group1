import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-expansion-panel',
  templateUrl: './expansion-panel.component.html',
  styleUrls: ['./expansion-panel.component.scss']
})
export class ExpansionPanelComponent implements OnInit {

  expansionPanelFilters = [true, true, true, true, true]; // Account, Amount, Branch, Name, Time
  
  constructor() { }

  ngOnInit(): void {
  }

}
