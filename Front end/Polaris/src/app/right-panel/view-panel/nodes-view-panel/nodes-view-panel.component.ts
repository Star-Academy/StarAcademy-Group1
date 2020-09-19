
import { DataOnScreenService } from './../../../../services/data-on-screen.service';

import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-nodes-view-panel',
  templateUrl: './nodes-view-panel.component.html',
  styleUrls: ['./nodes-view-panel.component.scss'],
})
export class NodesViewPanelComponent implements OnInit {
  public nodes;
  public hidden = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public ogmaProvider: OgmaHandlerService,
    public dataOnScreen: DataOnScreenService
  ) {}

  ngOnInit(): void {}

  public getNodeById(nodeId: string): string {
    return (
      this.ogmaProvider.ogma.getNode(nodeId).getData('OwnerName') +
      ' ' +
      this.ogmaProvider.ogma.getNode(nodeId).getData('OwnerFamilyName')
    );
  }

  public isNodeSelected(nodeId: string): boolean {
    return this.ogmaProvider.ogma.getNode(nodeId).isSelected();
  }

  public updateResult(input: string) {
    this.nodes = [];
    this.ogmaProvider.ogma.getNodes().getId().forEach((element) => {

      if (element.indexOf(input) != -1 || this.getNodeById(element).indexOf(input) != -1)
          this.nodes.push(element);
      });
      console.log("yessss");
  }
}
