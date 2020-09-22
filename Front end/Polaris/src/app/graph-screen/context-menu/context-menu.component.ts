import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { OgmaHandlerService } from './../../../services/ogma-handler.service';
import { Component, OnInit, Input } from '@angular/core';
import { GraphHandlerService } from './../../services/main-graph.service';

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

  constructor(private randomOgma: GraphHandlerService, private componentCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}

  public deleteNode() {
    let removeOne: string[] = new Array(this.content.id);
    this.randomOgma.removeNodes(removeOne);
    this.randomOgma.graphChanged.emit();
    this.componentCommunication.onClickContextMenu.emit();
  }

  public expandNode() {
    this.randomOgma.expandOneNode(this.content.id);
    this.randomOgma.graphChanged.emit();
    this.componentCommunication.onClickContextMenu.emit();

  }
  public copyNodeId() {
    navigator.clipboard.writeText(this.content.id)
      .then(() => {
        console.log('Text copied to clipboard');
      })
      .catch(err => {
        console.error('Error in copying text: ', err);
      });
    this.componentCommunication.onClickContextMenu.emit();
  }
}
