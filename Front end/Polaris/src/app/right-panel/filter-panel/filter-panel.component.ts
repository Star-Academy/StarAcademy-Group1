import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-filter-panel',
  templateUrl: './filter-panel.component.html',
  styleUrls: ['./filter-panel.component.scss']
})
export class FilterPanelComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public openNav() {
    document.getElementById("mySidenav2").style.width = "250px";
  }

  /* Set the width of the side navigation to 0 */
  public closeNav() {
    document.getElementById("mySidenav2").style.width = "0";
  }

}
