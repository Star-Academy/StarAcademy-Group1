import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-paths-panel',
  templateUrl: './paths-panel.component.html',
  styleUrls: ['./paths-panel.component.scss']
})
export class PathsPanelComponent implements OnInit {


   public paths : string[][]=[["10","9","8"],["7","8","9"]];

  constructor() { }

  ngOnInit(): void {
  }


}
