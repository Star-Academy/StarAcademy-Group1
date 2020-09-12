import { Component, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';

@Component({
  selector: 'app-edge-info-box',
  templateUrl: './edge-info-box.component.html',
  styleUrls: ['./edge-info-box.component.scss']
})
export class EdgeInfoBoxComponent implements OnInit {

  constructor(public componentsCommunication: ComponentsCommunication) { }

  ngOnInit(): void {
  }

}
