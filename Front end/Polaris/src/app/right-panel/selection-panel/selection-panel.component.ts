<<<<<<< HEAD
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';
import { RandomGraphService } from './../../../services/read-ogma-from-random-json.service';
=======
import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
>>>>>>> 82c391c34bee8ee3a39a8c206ea818abbd5cab2d


@Component({
  selector: 'app-selection-panel',
  templateUrl: './selection-panel.component.html',
  styleUrls: ['./selection-panel.component.scss']
})
export class SelectionPanelComponent implements OnInit {
  public hidden = false;
  constructor(public componentCommunication: ComponentsCommunication, public randomOgma: RandomGraphService) { }

  ngOnInit(): void {

  }
  public openNav() {
    document.getElementById("mySidenav").style.width = "250px";
  }

  public closeNav() {
    document.getElementById("mySidenav").style.width = "0";
  }
  public getNodeById(nodeId: string): string {
    return this.randomOgma.ogma.getNode(nodeId).getData('OwnerName') + " " + this.randomOgma.ogma.getNode(nodeId).getData('OwnerFamilyName');
  }
}
