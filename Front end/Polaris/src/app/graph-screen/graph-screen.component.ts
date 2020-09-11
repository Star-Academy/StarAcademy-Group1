import { Component, OnInit, AfterContentInit, ViewChild } from '@angular/core';
import * as initialGraph from '../../assets/ogma.min.js';
import { RandomGraphService } from '../../services/read-ogma-from-random-json.service';

@Component({
  selector: 'app-graph-screen',
  templateUrl: './graph-screen.component.html',
  styleUrls: ['./graph-screen.component.scss']
})
export class GraphScreenComponent implements OnInit, AfterContentInit {
  @ViewChild('ogmaContainer', { static: true })
  private container;
  constructor(private randomOgma: RandomGraphService) { }

  ngOnInit() {
    this.randomOgma.initConfig({
      graph: initialGraph,
      options: {
        backgroundColor: 'rgb(240, 240, 240)'
      }
    });
  }
  ngAfterContentInit() {
    this.randomOgma.ogma.setContainer(this.container.nativeElement);
    return this.runLayout();
  }

  public runLayout(): Promise<void> {
    return this.randomOgma.runLayout();
  }
  public getJs(): Promise<void> {
    this.randomOgma.getJsonGraph();
    return this.runLayout();
  }

}
