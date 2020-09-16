
import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { OgmaHandlerService } from './../../../../services/ogma-handler.service';

@Component({
  selector: 'nodes-view-panel-panel',
  templateUrl: './nodes-view-panel.component.html',
  styleUrls: ['./nodes-view-panel.component.scss']
})
export class NodesViewPanelComponent implements OnInit {
  public hidden = false;
  constructor(public componentCommunication: ComponentsCommunicationService, public randomOgma: OgmaHandlerService) { }

  ngOnInit(): void {

  }
  public openNav() {
    document.getElementById("mySidenav").style.width = "250px";
  }

  public closeNav() {
    document.getElementById("mySidenav").style.width = "0";
  }

  public getNodeById(nodeId: string): string {
    return this.randomOgma.ogma.getNode(nodeId).getData('OwnerName') + " " + this.randomOgma.ogma.getNode(nodeId).getData('OwnerFamilyName');
  }

  public isSelectedNodeById(nodeId: string): boolean {
    return this.randomOgma.ogma.getNode(nodeId).isSelected();
  }
}
