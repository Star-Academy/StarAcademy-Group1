import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-panels-menu',
  templateUrl: './panels-menu.component.html',
  styleUrls: ['./panels-menu.component.scss'],
})
export class PanelsMenuComponent implements OnInit {
  flowIconPath = '../../../assets/flowIcon.png';
  pathIconPath = '../../../assets/pathIcon.png';
  expandIconPath = '../../../assets/expandIcon.png';
  addNodeIconPath = '../../../assets/addIcon.png';

  constructor(public componentCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}
}
