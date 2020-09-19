import { Injectable } from '@angular/core';
import { NodeInfo } from 'src/app/right-panel/information-panel/node-info-box/NodeInfo';
import { EdgeInfo } from 'src/app/right-panel/information-panel/edge-info-box/EdgeInfo';

@Injectable()
export class ComponentsCommunicationService {

  public whichPanel: string;
  public whichLeftSideNav: number = 0;
  public graphCreated: boolean = false;
  public nodeInfo: NodeInfo
  public edgeInfo: EdgeInfo
  public graphInfo: {
    graphSize: number,
    edgeSize: number
  }

  public buttonTextMap = new Map([
    ["expansion", "بسط بده"],
    ["flow", "محاسبه فلو :-؟"],
    ["path", "نمایش مسیرها"],
    ["addNode", "اضافه کردن راس"]
  ]);

  public filtersToShowMap = new Map([
    // Account, Amount, Branch, Name, Time
    ["expansion", [false, true, false, true, true]],
    ["flow", [true, true, true, true, true]],
    ["path", [true, true, true, true, true]],
    ["addNode", [true, true, true, true, true]]
  ]);
}
