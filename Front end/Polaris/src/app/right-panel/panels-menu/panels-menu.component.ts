import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-panels-menu',
  templateUrl: './panels-menu.component.html',
  styleUrls: ['./panels-menu.component.scss']
})
export class PanelsMenuComponent implements OnInit {

  constructor(public componentCommunication: ComponentsCommunicationService) { }

  ngOnInit(): void {
  }

}
