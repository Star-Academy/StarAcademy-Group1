import { GraphHandlerService } from './../../../services/main-graph.service';
import { DataOnScreenService } from './../../../../services/data-on-screen.service';
import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-nodes-view-panel',
  templateUrl: './nodes-view-panel.component.html',
  styleUrls: ['./nodes-view-panel.component.scss'],
})
export class NodesViewPanelComponent implements OnInit {
  public nodes;
  public hidden = false;
  public searched : string = "";

  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public ogmaProvider: GraphHandlerService,
    public dataOnScreen: DataOnScreenService
  ) {ogmaProvider.graphChanged.subscribe(()=> this.updateResult(this.searched))}

  ngOnInit(): void {}

  public getNodeById(nodeId: string): string {
    return (
      this.ogmaProvider.ogma.getNode(nodeId).getData('ownerName') +
      ' ' +
      this.ogmaProvider.ogma.getNode(nodeId).getData('ownerFamilyName')
    );
  }

  public isNodeSelected(nodeId: string): boolean {
    return this.ogmaProvider.ogma.getNode(nodeId).isSelected();
  }

  public updateResult(input : string) {
    this.searched = input ;
    this.nodes = [];
    this.ogmaProvider.ogma.getNodes().getId().forEach((element) => {
      console.log(element);
      if (element.indexOf(input) != -1 || this.getNodeById(element).indexOf(input) != -1)
          this.nodes.push(element);
      });

  }
}
