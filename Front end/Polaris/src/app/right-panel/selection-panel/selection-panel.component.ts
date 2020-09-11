import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-selection-panel',
  templateUrl: './selection-panel.component.html',
  styleUrls: ['./selection-panel.component.scss']
})
export class SelectionPanelComponent implements OnInit {

  public hidden = false ;
  constructor() { }

  ngOnInit(): void {
  }
  public openNav() {
    document.getElementById("mySidenav").style.width = "250px";
  }

  /* Set the width of the side navigation to 0 */
  public closeNav() {
    document.getElementById("mySidenav").style.width = "0";
  }

}
