import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import {faFilter} from '@fortawesome/free-solid-svg-icons';
import {faCheck} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-panels-menu',
  templateUrl: './panels-menu.component.html',
  styleUrls: ['./panels-menu.component.scss']
})
export class PanelsMenuComponent implements OnInit {

  filterIcon = faFilter;
  checkIcon = faCheck;
  constructor(public componentCommunication: ComponentsCommunicationService) { }

  ngOnInit(): void {
  }

}
