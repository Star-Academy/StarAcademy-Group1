import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {
  @Input()
  public nodeId:string;
  @Input()
  public nodePerson: string;
  constructor() { }

  ngOnInit(): void {
  }

}
