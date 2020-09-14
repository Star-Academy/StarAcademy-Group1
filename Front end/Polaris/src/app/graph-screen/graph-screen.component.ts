import { Component, OnInit, AfterContentInit, ViewChild } from '@angular/core';
import * as initialGraph from '../../assets/ogma.min.js';
import { RandomGraphService } from '../../services/read-ogma-from-random-json.service';
import { ComponentsCommunication } from '../../services/components-communication.service';
import { NodeId } from '../../assets/ogma.min.js';
import * as HoverEvent from '../../assets/ogma.min.js';
import * as RightClickEvent from '../../assets/ogma.min.js';
import * as ClickEvent from '../../assets/ogma.min.js';

@Component({
  selector: 'app-graph-screen',
  templateUrl: './graph-screen.component.html',
  styleUrls: ['./graph-screen.component.scss'],
})
export class GraphScreenComponent implements OnInit, AfterContentInit {
  @ViewChild('ogmaContainer', { static: true })
  private container;
  hoveredContent: {
    id: NodeId;
    accountId: number;
    name: string;
    familyName: string;
  };
  hoveredPosition: { x: number; y: number };
  contextMenuPosition: { x: number; y: number };
  contextMenuContent: { id: NodeId };
  constructor(
    private randomOgma: RandomGraphService,
    private componentCommunication: ComponentsCommunication
  ) { }

  ngOnInit() {
    this.randomOgma.initConfig({
      graph: initialGraph,
      options: {
        backgroundColor: 'rgb(240, 240, 240)',
      },
    });
    this.randomOgma.ogma.events.onHover(({ x, y, target }: HoverEvent) => {
      if (target.isNode) {
        this.hoveredContent = {
          id: target.getId(),
          accountId: target.getData('AccountID'),
          name: target.getData('OwnerName'),
          familyName: target.getData('OwnerFamilyName'),
        };
        this.hoveredPosition = { x, y: y + 20 };
      }
    });

    this.randomOgma.ogma.events.onUnhover((_: HoverEvent) => {
      this.hoveredContent = null;
    });

    this.randomOgma.ogma.events.onClick(
      ({ x, y, target, button }: RightClickEvent) => {
        if (target != null && target.isNode && button === 'right') {
          this.contextMenuContent = { id: target.getId() };
          this.contextMenuPosition = { x, y: y + 20 };
        }
      }
    );
    this.randomOgma.ogma.events.onClick(({ target }: ClickEvent) => {
      this.hoveredContent = null;
      if (target == null || !target.isNode) {
        this.contextMenuContent = null;
        this.contextMenuPosition = null;
      }
    });
    this.randomOgma.ogma.events.onClick(
      ({ target, button }: ClickEvent) => {
        if (target != null && target.isNode && button === 'left') {
          this.componentCommunication.whichPanel = 'nodeInfo';
          this.componentCommunication.nodeInfo = {
            accountId: target.getId(),
            name: target.getData('OwnerName'),
            familyName: target.getData('OwnerFamilyName'),
            branchName: target.getData('BranchName'),
          }
        }
        else if (target != null && !target.isNode && button === 'left') {
          this.componentCommunication.whichPanel = 'edgeInfo';
          this.componentCommunication.edgeInfo = {
            Id: target.getId(),
            source: target.getSource().getId(),
            target: target.getTarget().getId()
          }
        }
      }
    );
    this.randomOgma.ogma.events.onNodesSelected(() => {
      // console.log(this.randomOgma.ogma.getSelectedNodes());
      // this.randomOgma.ogma.getSelectedNodes().getId().forEach(element => {
      //   this.randomOgma.addNodeToSelected(element);
      // });
    });

    this.randomOgma.ogma.events.onNodesUnselected(() => {
      //   this.randomOgma.ogma.getNonSelectedNodes().getId().forEach(element => {
      //     if (this.randomOgma.selectedNodes.includes(element)) {
      //       const index = this.randomOgma.selectedNodes.indexOf(element, 0);
      //       if (index > -1) {
      //         this.randomOgma.selectedNodes.splice(index, 1);
      //       }
      //     }
      //   });
      // console.log(this.randomOgma.ogma.getSelectedNodes());
    });
    this.randomOgma.ogma.events.onDragStart(() => {
      if (this.randomOgma.ogma.keyboard.isKeyPressed('ctrl')) {
        this.randomOgma.ogma.getSelectedNodes().setSelected(false);
        this.randomOgma.ogma.getSelectedEdges().setSelected(false);
        this.randomOgma.ogma.tools.rectangleSelect.enable({
          bothExtremities: true,
          callback({ nodes, edges }) {
            nodes.setSelected(true);
            edges.setSelected(true);
          }
        });
      }
      console.log(this.randomOgma.ogma.getSelectedNodes());
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
    this.componentCommunication.graphCreated = true;
    return this.runLayout();
  }

}
