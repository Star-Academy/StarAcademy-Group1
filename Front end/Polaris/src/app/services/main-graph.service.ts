import { Injectable } from '@angular/core';
import * as Ogma from '../../assets/ogma.min.js';
import { NodeService } from './node/node.service';
import {GraphService} from './graph/graph.service';
@Injectable()
export class GraphHandlerService {
    public ogma: Ogma;
    public selectedNodes: Array<string>;
    public nodeService: NodeService;
    public graphService: GraphService;

    public initOgma(configuration = {}) {
        this.ogma = new Ogma(configuration);
    }
    public runLayout(): Promise<void> {
        return this.ogma.layouts.force({ locate: true });
    }
    public addNodesByid(ids: string[]) {
        let graphJson = this.nodeService.getNodes(ids,-1,-1);
        // this.ogma.parse.json(graphJson).then((graph) => this.addNodes(graph));
        // this.ogma.parse.json(graphJson)
        this.ogma.addNodes(graphJson);
    }
    public setGraph(graph) {
        this.ogma.setGraph(graph);
        this.runLayout();
    }
    
    public expandNodes(ids: string[]){
        let expansions = this.graphService.getNodesExpansion(ids);
        
    }

    public removeNodes(ids : string[]){
        
    }

}