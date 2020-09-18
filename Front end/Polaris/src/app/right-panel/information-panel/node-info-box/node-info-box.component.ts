import { Component, Input, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { NodeInfo } from './NodeInfo';
@Component({
  selector: 'app-node-info-box',
  templateUrl: './node-info-box.component.html',
  styleUrls: ['./node-info-box.component.scss'],
})
export class NodeInfoBoxComponent implements OnInit {
  public get node() {
    return this.componentsCommunication.nodeInfo;
  }
  //todo : yek class node tarif konid va inja ye object azash besazid ke shooloogh nashe
  constructor(public componentsCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}
}
