import { GraphHandlerService } from './../../../../services/main-graph.service';
import { Component, OnInit, Input } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
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

  constructor(public ogmaProvider: GraphHandlerService , public componentCommunication : ComponentsCommunicationService) { }

  ngOnInit(): void {
  }

  public changeChecked(isChecked: boolean) {
    if (isChecked) {
      this.ogmaProvider.ogma.getNode(this.nodeId).setSelected(true);
    }
    else {
      this.ogmaProvider.ogma.getNode(this.nodeId).setSelected(false);
    }
  }
  public showInfo(){
  this.componentCommunication.whichPanel = "nodeInfo";
    let node = this.ogmaProvider.ogma.getNode(this.nodeId)
    this.componentCommunication.nodeInfo = {
      ownerName: node.getData('ownerName'),
      ownerFamilyName: node.getData('ownerFamilyName'),
      accountId: node.getId(),
      accountType: node.getData('accountType'),
      sheba: node.getData('sheba'),
      cardId: node.getData('cardId'),
      ownerId: node.getData('ownerId'),
      branchName: node.getData('branchName'),
      branchAddress: node.getData('branchAddress'),
      branchTelephone: node.getData('branchTelephone'),
    }
  }

}
