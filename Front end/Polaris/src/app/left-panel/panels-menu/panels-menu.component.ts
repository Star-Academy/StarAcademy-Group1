import { ConstValuesService } from 'src/services/const-values.service';
import { GraphHandlerService } from './../../services/main-graph.service';
import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-panels-menu',
  templateUrl: './panels-menu.component.html',
  styleUrls: ['./panels-menu.component.scss'],
})
export class PanelsMenuComponent implements OnInit {
  flowIconPath = '../../../assets/flowIcon.png';
  pathIconPath = '../../../assets/pathIcon.png';
  expandIconPath = '../../../assets/expandIcon.png';
  addNodeIconPath = '../../../assets/addIcon.png';

  constructor(public componentCommunication: ComponentsCommunicationService, private graphProvider: GraphHandlerService, private constVlues:ConstValuesService) {}

  ngOnInit(): void {}

  public onIconClick(id: string){
    if (id === 'selection-icon'){
      this.componentCommunication.whichLeftSideNav = 1;
    }
    if (id === 'path-icon'){
      this.componentCommunication.whichLeftSideNav = 2;
    }
    if (id === 'flow-icon'){
      this.componentCommunication.whichLeftSideNav = 3;
    }
    if (id === 'add-icon'){
      this.componentCommunication.whichLeftSideNav = 4;
    }
    this.graphProvider.ogma.getEdges().setAttributes({color: this.constVlues.standardEdgeColor, text: null, width: 1});
    this.graphProvider.ogma.getNodes().setAttributes({color: this.constVlues.standardNodeColor, text: null});
  }


}
