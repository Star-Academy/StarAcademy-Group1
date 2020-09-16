import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-paths-panel',
  templateUrl: './paths-panel.component.html',
  styleUrls: ['./paths-panel.component.scss']
})
export class PathsPanelComponent implements OnInit {

  PathsPanelFilters = [true, true, true, true, true]; // Account, Amount, Branch, Name, Time
  
  constructor() { }

  ngOnInit(): void {
  }

}
