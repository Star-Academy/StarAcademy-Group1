import { Injectable } from '@angular/core';
import * as Ogma from '../assets/ogma.min.js';
@Injectable()
export class RandomGraphService{
    public ogma:Ogma;

    public initConfig(configuration = {}) {
        this.ogma = new Ogma(configuration);
    }

    public runLayout(): Promise<void> {
        return this.ogma.layouts.force({ locate: true });
    }

    public getJsonGraph() {
        this.ogma.parse.jsonFromUrl('../assets/data2.json').then((graph) => this.setGraph(graph));
    }

    public setGraph(graph) {
        this.ogma.setGraph(graph);
        this.runLayout();
    }

    public removeGraphNode() {
        let x: Array<string>;
        x = ['sss', 'aaaaa'];
        this.ogma.removeNodes(x);
    }
}