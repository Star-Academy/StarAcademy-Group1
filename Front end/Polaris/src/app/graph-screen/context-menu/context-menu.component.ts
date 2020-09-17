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

  constructor(private randomOgma: OgmaHandlerService) {}

  ngOnInit(): void {}

  public deleteNode() {
    let removeOne: string[] = new Array(this.content.id);
    this.randomOgma.removeGraphNode(removeOne);
  }
  // public deleteNodeFromSelected() {
  //   this.randomOgma.deleteNodeFromSelected(this.content.id);
  //   console.log(this.randomOgma.selectedNodes);
  // }
  // public addNodeToSelected() {
  //   this.randomOgma.addNodeToSelected(this.content.id);
  //   console.log(this.randomOgma.selectedNodes);
  // }
}
