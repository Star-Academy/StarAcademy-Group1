import { Component, Input, OnInit } from '@angular/core';
import { ComponentsCommunication } from 'src/services/components-communication.service';
import { NodeBox } from './../../../node';

@Component({
  selector: 'app-node-info-box',
  templateUrl: './node-info-box.component.html',
  styleUrls: ['./node-info-box.component.scss']
})

export class NodeInfoBoxComponent implements OnInit {

  constructor(public componentCommunication: ComponentsCommunication) {

  }

  ngOnInit(): void {
  }

}
