import { OgmaHandlerService } from './../../../../services/ogma-handler.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {
  @Input()
  public nodeId: string;
  @Input()
  public nodePerson: string;
  @Input()
  public isSelected: boolean;

  constructor(public ogmaProvider: OgmaHandlerService) { }

  ngOnInit(): void {
  }
  public changeChecked(isChecked: boolean) {
    if (isChecked) {
      this.ogmaProvider.ogma.getNode(this.nodeId).setSelected(true);
    }
    else {
      this.ogmaProvider.ogma.getNode(this.nodeId).setSelected(false);
      for (let oneEdge of this.ogmaProvider.ogma.getSelectedEdges().getId()) {
        if (!this.ogmaProvider.ogma.getEdge(oneEdge).getSource().isSelected() || !this.ogmaProvider.ogma.getEdge(oneEdge).getTarget().isSelected()) {
          this.ogmaProvider.ogma.getEdge(oneEdge).setSelected(false);
        }
      }

    }
    // console.log( this.ogmaProvider.ogma.getSelectedEdges());
    console.log( this.ogmaProvider.ogma.getSelectedNodes());


  }

}
