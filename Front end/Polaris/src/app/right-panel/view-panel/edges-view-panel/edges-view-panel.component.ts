import { GraphHandlerService } from './../../../services/main-graph.service';
import { DataOnScreenService } from './../../../../services/data-on-screen.service';

import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-edges-view-panel',
  templateUrl: './edges-view-panel.component.html',
  styleUrls: ['./edges-view-panel.component.scss'],
})
export class EdgesViewPanelComponent implements OnInit {
  public flag: boolean = true;
  public edges: string[];
  public hidden = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public ogmaProvider: GraphHandlerService,
    public dataOnScreen: DataOnScreenService
  ) {}

  ngOnInit(): void {}

  public isEdgeSelected(edgeId: string): boolean {
    return this.ogmaProvider.ogma.getEdge(edgeId).isSelected();
  }
  public updateResult(input: string) {
    this.edges = [];
    this.ogmaProvider.ogma.getEdges().getId().forEach((element) => {
        if (element.indexOf(input) != -1) this.edges.push(element);
      });
    console.log(this.ogmaProvider.ogma.getEdges().getId());
  }
}
