import { Component, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';
import { MatFormFieldControl, MatFormField } from '@angular/material/form-field';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-filter-panel',
  templateUrl: './filter-panel.component.html',
  styleUrls: ['./filter-panel.component.scss']
})
export class FilterPanelComponent implements OnInit {

  public hidden = false;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  constructor(public componentCommunication: ComponentsCommunication) { }

  ngOnInit(): void {
  }

}
