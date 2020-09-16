import { Component, Input, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {
  @Input()
  whichToShow : boolean[];

  public hidden = false;
  panelOpenState = false;
  constructor(public componentCommunication: ComponentsCommunicationService) { }

  ngOnInit(): void {
  }

}
