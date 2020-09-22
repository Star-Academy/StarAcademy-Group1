import { OgmaHandlerService } from 'src/services/ogma-handler.service';
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
  public searched: string = "";
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public ogmaProvider: GraphHandlerService,
    public dataOnScreen: DataOnScreenService
  ) { ogmaProvider.graphChanged.subscribe(() => this.updateResult(this.searched)) }

  ngOnInit(): void { }

  public isEdgeSelected(edgeId: string): boolean {
    if (this.ogmaProvider.ogma.getEdge(edgeId))
      return this.ogmaProvider.ogma.getEdge(edgeId).isSelected();
    else
      return false;
  }
  public updateResult(input: string) {
    this.searched = input;
    this.edges = [];
    this.ogmaProvider.ogma.getEdges().getId().forEach((element) => {
      if (element.indexOf(input) != -1) this.edges.push(element);
    });
  }
}
