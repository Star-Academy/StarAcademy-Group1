import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-edge-info-box',
  templateUrl: './edge-info-box.component.html',
  styleUrls: ['./edge-info-box.component.scss'],
})
export class EdgeInfoBoxComponent implements OnInit {
  constructor(public componentsCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}

  public dateGenerator(): string {
    let date = new Date(+this.componentsCommunication.edgeInfo.date * 1000);
    let year = date.getFullYear();
    let month = date.getMonth();
    let day = date.getDate();
    return year + "/" + month + "/" + day;
  }
}
