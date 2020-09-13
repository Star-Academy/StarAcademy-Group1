import { Component, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-filter-panel',
  templateUrl: './filter-panel.component.html',
  styleUrls: ['./filter-panel.component.scss']
})
export class FilterPanelComponent implements OnInit {
  public hidden = false;
  panelOpenState = false;
  constructor(public componentCommunication: ComponentsCommunication) { }

  ngOnInit(): void {
  }

}
