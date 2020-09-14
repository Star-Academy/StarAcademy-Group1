import { Component, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';

@Component({
  selector: 'app-right-panel',
  templateUrl: './right-panel.component.html',
  styleUrls: ['./right-panel.component.scss']
})
export class RightPanelComponent implements OnInit {



  constructor(public componentCommunication: ComponentsCommunication) { }

  ngOnInit(): void {
  }

}
