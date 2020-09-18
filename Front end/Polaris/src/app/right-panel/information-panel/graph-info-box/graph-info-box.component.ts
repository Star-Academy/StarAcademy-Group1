import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-graph-info-box',
  templateUrl: './graph-info-box.component.html',
  styleUrls: ['./graph-info-box.component.scss'],
})
export class GraphInfoBoxComponent implements OnInit {
  public get graph() {
    return this.componentsCommunication.graphInfo;
  }
  constructor(public componentsCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}
}
