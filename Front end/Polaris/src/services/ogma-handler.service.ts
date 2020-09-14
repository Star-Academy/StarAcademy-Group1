import { Injectable } from '@angular/core';
import * as Ogma from '../assets/ogma.min.js';
@Injectable()
export class OgmaHandlerService {
  public ogma: Ogma;
  public selectedNodes: Array<string>;

  public initConfig(configuration = {}) {
    this.ogma = new Ogma(configuration);
    this.selectedNodes = new Array<string>();
  }

  public runLayout(): Promise<void> {
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
    // if (!this.selectedNodes.includes(id)) {
    //   this.selectedNodes.push(id);
    // }
    this.ogma.getNode(id).setSelected(true);
    console.log(this.ogma.getSelectedNodes());
  }

  public deleteNodeFromSelected(id: string) {
    // const index = this.selectedNodes.indexOf(id, 0);
    // if (index > -1) {
    //   this.selectedNodes.splice(index, 1);
    // }
    this.ogma.getNode(id).setSelected(false);
  }
}
