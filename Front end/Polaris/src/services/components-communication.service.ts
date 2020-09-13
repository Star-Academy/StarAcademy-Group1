import { Injectable } from '@angular/core';
@Injectable()
export class ComponentsCommunication {

  public whichPanel: string;
  public whichRightSideNav : number = 1 ;

  public nodeInfo: {
    accountId: string;
    name: string;
    familyName: string;
    branchName: string;
  };
  public edgeInfo: {
    Id: string;
    source: string,
    target: string
  }
}
