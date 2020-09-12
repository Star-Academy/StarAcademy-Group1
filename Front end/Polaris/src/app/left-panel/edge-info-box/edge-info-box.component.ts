import { Component, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';

@Component({
  selector: 'app-edge-info-0',
  templateUrl: './edge-info-box.component.html',
  styleUrls: ['./edge-info-box.component.scss']
})
export class EdgeInfoBoxComponent implements OnInit {

  constructor(public componentsCommunication: ComponentsCommunication) { }

  ngOnInit(): void {
    console.log('here we are');
  }

}
