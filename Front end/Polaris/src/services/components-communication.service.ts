import { Injectable } from '@angular/core';
import { NodeInfo } from 'src/app/right-panel/node-info-box/NodeInfo';
@Injectable()
export class ComponentsCommunicationService {

  public whichPanel: string;
  public whichRightSideNav : number = 0 ;
  public graphCreated: boolean = false;

  public nodeInfo: NodeInfo
  public edgeInfo: {
    Id: string;
    source: string,
    target: string
  }
}
