import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-panel',
  templateUrl: './view-panel.component.html',
  styleUrls: ['./view-panel.component.scss']
})
export class ViewPanelComponent implements OnInit {

  public backColor: string = 'black';
  public mainColor: string = 'white';
  constructor() { }

  ngOnInit(): void {
  }

}
