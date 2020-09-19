import { GraphHandlerService } from './../../../../services/main-graph.service';

import { Component, OnInit, Input } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

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
      for (let oneEdge of this.ogmaProvider.ogma.getSelectedEdges().getId()) {
      }

    }
  }
  public showInfo(){
  this.componentCommunication.whichPanel = "nodeInfo";
    let node = this.ogmaProvider.ogma.getNode(this.nodeId)
    this.componentCommunication.nodeInfo = {
      ownerName: node.getData('OwnerName'),
      ownerFamilyName: node.getData('OwnerFamilyName'),
      accountId: node.getId(),
      accountType: node.getData('AccountType'),
      sheba: node.getData('Sheba'),
      cardId: node.getData('CardId'),
      ownerId: node.getData('OwnerId'),
      branchName: node.getData('BranchName'),
      branchAddress: node.getData('BranchAddress'),
      branchTelephone: node.getData('BranchTelephone'),
    }
  }

}
