import { Component, Input, OnInit } from '@angular/core';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-path-card',
  templateUrl: './path-card.component.html',
  styleUrls: ['./path-card.component.scss']
})
export class PathCardComponent implements OnInit {

  @Input()
  id : number

  @Input()
  edges : string[]

  @Input()
  nodes : string[]

  public amount: number = 0;

  constructor(public ogmaHandler: OgmaHandlerService) {  }

  ngOnInit(): void {
    this.findAmount();
  }

  public findAmount(){
    for(let edgeId of this.edges){
      this.amount+= this.ogmaHandler.ogma.getEdge(edgeId).getData('amount');
    }
    this.amount /= 1000000;
  }
  public getHoverData(): string{

  }

}
