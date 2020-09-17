
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
        let node = this.ogmaProvider.ogma.getNode(this.edgeId)
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
        console.log( this.componentCommunication.whichPanel);
      }
  }

