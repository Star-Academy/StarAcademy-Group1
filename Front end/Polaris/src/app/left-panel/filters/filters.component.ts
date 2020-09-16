import { Component, Input, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {
  @Input()
  panel: string;

  public hidden = false;
  panelOpenState = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public filterService: FilterService
  ) { }

  ngOnInit(): void {
  }
}
