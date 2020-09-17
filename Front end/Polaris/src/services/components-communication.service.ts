import { Injectable } from '@angular/core';
import { NodeInfo } from 'src/app/right-panel/information-panel/node-info-box/NodeInfo';
@Injectable()
export class ComponentsCommunicationService {

  public whichPanel: string;
  public whichLeftSideNav: number = 0;
  public graphCreated: boolean = false;

  public nodeInfo: NodeInfo
  public edgeInfo: {
    Id: string;
    source: string,
    target: string,
    date: string,
    amount: number,
    type: string
  }
  public graphInfo: {
    graphSize: number,
    edgeSize: number
  }

  public filtersToShowMap = new Map([
    // Account, Amount, Branch, Name, Time
    ["expansion", [true, true, true, true, true]],
    ["flow", [true, true, true, true, true]],
    ["path", [true, true, true, true, true]]
  ]);

  public buttonTextMap = new Map([
    ["expansion", "اکسپند کن :-؟"],
    ["flow", "محاسبه فلو :-؟"],
    ["path", "نمایش مسیر :-؟"]
  ]);
}
