import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { faExpand, faBug, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-panels-menu',
  templateUrl: './panels-menu.component.html',
  styleUrls: ['./panels-menu.component.scss'],
})
export class PanelsMenuComponent implements OnInit {
  expansionIcon = faExpand;
  notDecidedIcon = faBug;
  addNewNodeIcon = faPlus;

  constructor(public componentCommunication: ComponentsCommunicationService) {}

  ngOnInit(): void {}
}
