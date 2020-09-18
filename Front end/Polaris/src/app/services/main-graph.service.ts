import { Injectable } from '@angular/core';
import * as Ogma from '../../assets/ogma.min.js';
import { NodeService } from './node/node.service';
import { GraphService } from './graph/graph.service';
import { isDataSource } from '@angular/cdk/collections';
@Injectable()
export class GraphHandlerService {
  public ogma: Ogma;
  public selectedNodes: Array<string>;
  public nodeColor: string;
  public edgeColor: string;
  constructor(public nodeService: NodeService, public graphService: GraphService){

  }

  public initOgma(configuration = {}) {
    this.ogma = new Ogma(configuration);
  }
  public runLayout(): Promise<void> {
    return this.ogma.layouts.force({ locate: true });
  }
  public getJsonGraph() {
    this.ogma.parse
      .jsonFromUrl('../../assets/data2.json')
      .then((graph) => this.setGraph(graph));
  }
  public setGraph(graph) {
    this.ogma.setGraph(graph);
    this.runLayout();
  }

  public async getNodeByid(id: string): Promise<JSON> {
    let graphJson = await this.nodeService.getNode(id);
    return graphJson;
  }

  public async addNode(id:string) {
    let nodeResult = await this.getNodeByid(id);
    this.ogma.addNode(nodeResult);
  }

  public expandNodes(
    ids: string,
    nodeFilters: string[],
    edgeFilters: string[]
  ) {
    let expansions = this.graphService.getExpansion(
      ids,
      nodeFilters,
      edgeFilters
    );
  }
  public getMaxFlow(
    sourceId: string,
    targetId: string,
    nodeFilters: string[],
    edgeFilters: string[]
  ) {
    let flow = this.graphService.getFlow(
      sourceId,
      targetId,
      nodeFilters,
      edgeFilters
    );
  }
  public findPaths(
    sourceId: string,
    targetId: string,
    nodeFilters: string[],
    edgeFilters: string[]
  ) {
    let paths = this.graphService.getPaths(
      sourceId,
      targetId,
      nodeFilters,
      edgeFilters
    );
  }
  public addByFilter(filters: string[]) {
    let nodes = this.nodeService.getNodes(filters, -1, -1);
  }

  public removeNodes(ids: string[]) {
    this.ogma.removeNodes(ids);
  }
  public setNodesAttributes(ids: string[]) {
    for (let node of ids) {
      this.ogma.getNode(node).setAttributes({ color: this.nodeColor });
    }
  }
  public setEdgesAttributes(ids: string[]) {
    for (let id of ids) {
      this.ogma.getEdge(id).setAttributes({ color: this.edgeColor });
    }
  }
}
