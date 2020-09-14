import { Injectable } from '@angular/core';
import { NodeInfo } from 'src/app/left-panel/node-info-box/NodeInfo';
@Injectable()
export class ComponentsCommunicationService {

  public whichPanel: string;
  public whichRightSideNav : number = 1 ;

  public nodeInfo: NodeInfo
  public edgeInfo: {
    Id: string;
    source: string,
    target: string
  }
}
