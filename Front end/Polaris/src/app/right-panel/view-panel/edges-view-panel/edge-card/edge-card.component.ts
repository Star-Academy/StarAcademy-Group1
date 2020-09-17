
import { Component, OnInit, Input } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-edge-card',
  templateUrl: './edge-card.component.html',
  styleUrls: ['./edge-card.component.scss']
})
export class EdgeCardComponent implements OnInit {
  @Input()
  public edgeId: string;
  @Input()
  public isSelected: boolean;

  constructor(public ogmaProvider: OgmaHandlerService , public componentCommunication : ComponentsCommunicationService) { }

  ngOnInit(): void {
  }
  public changeChecked(isChecked: boolean) {

    if (isChecked)
      this.ogmaProvider.ogma.getNode(this.edgeId).setSelected(true);
    else
      this.ogmaProvider.ogma.getNode(this.edgeId).setSelected(false);

    }
    public showInfo(){
      this.componentCommunication.whichPanel = "nodeInfo";
        let edge = this.ogmaProvider.ogma.getEdge(this.edgeId)
        this.componentCommunication.edgeInfo = {
          Id: edge.getId(),
          source: edge.getSource().getId(),
          target: edge.getTarget().getId(),
          type: edge.getData('type'),
          amount: edge.getData('amount'),
          date: edge.getData('date')
        }
  }
}

