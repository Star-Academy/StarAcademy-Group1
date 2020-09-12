import { RandomGraphService } from './../../../services/read-ogma-from-random-json.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-context-menu',
  templateUrl: './context-menu.component.html',
  styleUrls: ['./context-menu.component.scss']
})
export class ContextMenuComponent implements OnInit {

  @Input()
  content: { id: string };
  @Input()
  position: { x: number, y: number };

  constructor(private randomOgma: RandomGraphService) { }

  ngOnInit(): void {
  }
  public deleteNode() {
    let removeOne: string[] = new Array(this.content.id);
    this.randomOgma.removeGraphNode(removeOne);
  }
}
