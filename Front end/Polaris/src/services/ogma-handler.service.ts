import { EventEmitter, Injectable } from '@angular/core';
import * as Ogma from '../assets/ogma.min.js';
@Injectable()
export class OgmaHandlerService {
  public ogma: Ogma;
  public selectedNodes: Array<string>;
  public graphChanged : EventEmitter<void> = new EventEmitter<void>();

  public initConfig(configuration = {}) {
    this.ogma = new Ogma(configuration);
    this.selectedNodes = new Array<string>();
    this.ogma.styles.setSelectedNodeAttributes({outerStroke: function (node) {return node.isSelected() ? 'green' : null;}})
    this.ogma.styles.setSelectedEdgeAttributes({color: function (node) {return node.isSelected() ? 'green' : "gray"}})

  }

  public runLayout(): Promise<void> {
    this.graphChanged.emit();
    return this.ogma.layouts.force({ locate: true });
  }

  public getJsonGraph() {
    this.ogma.parse
      .jsonFromUrl('../assets/data2.json')
      .then((graph) => this.setGraph(graph));
  }

  public setGraph(graph) {
    this.ogma.setGraph(graph);
    this.runLayout();
  }

  public removeGraphNode(removingNodes: string[]) {
    this.ogma.removeNodes(removingNodes);
  }

  public addNodeToSelected(id: string) {
    this.ogma.getNode(id).setSelected(true);
    console.log(this.ogma.getSelectedNodes());
  }

  public deleteNodeFromSelected(id: string) {
    this.ogma.getNode(id).setSelected(false);
  }
}
