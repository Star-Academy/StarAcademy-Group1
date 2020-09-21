import { GraphHandlerService } from './../../services/main-graph.service';
import { OgmaHandlerService } from './../../../services/ogma-handler.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-context-menu',
  templateUrl: './context-menu.component.html',
  styleUrls: ['./context-menu.component.scss'],
})
export class ContextMenuComponent implements OnInit {
  @Input()
  content: { id: string };
  @Input()
  position: { x: number; y: number };

  constructor(private randomOgma: GraphHandlerService) {}

  ngOnInit(): void {}

  public deleteNode() {
    let removeOne: string[] = new Array(this.content.id);
    this.randomOgma.removeNodes(removeOne);
  }

  public expandNode(){
    this.randomOgma.expandOneNode(this.content.id);
  }
}
