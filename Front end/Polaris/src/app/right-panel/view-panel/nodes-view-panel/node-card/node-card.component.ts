
import { Component, OnInit, Input } from '@angular/core';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-node-card',
  templateUrl: './node-card.component.html',
  styleUrls: ['./node-card.component.scss']
})
export class NodeCardComponent implements OnInit {
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
        // if (!this.ogmaProvider.ogma.getEdge(oneEdge).getSource().isSelected() || !this.ogmaProvider.ogma.getEdge(oneEdge).getTarget().isSelected()) {
        //   this.ogmaProvider.ogma.getEdge(oneEdge).setSelected(false);
        // }
      }

    }
  }

}
