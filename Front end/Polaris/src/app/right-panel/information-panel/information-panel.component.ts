import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-information-panel',
  templateUrl: './information-panel.component.html',
  styleUrls: ['./information-panel.component.scss'],
})
export class InformationPanelComponent implements OnInit {
  constructor(public componentCommunication: ComponentsCommunicationService) { }

  isEmpty: boolean;
  ngOnInit(): void {


    if (this.componentCommunication.whichPanel === 'nodeInfo' ||
      this.componentCommunication.whichPanel === 'edgeInfo' ||
      this.componentCommunication.whichPanel === 'graphInfo'
    )
      this.isEmpty = false;
    else
      this.isEmpty = true;

    console.log(this.isEmpty);

  }
}
