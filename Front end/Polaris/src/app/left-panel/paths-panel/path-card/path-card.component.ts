import { Component, Input, OnInit } from '@angular/core';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-path-card',
  templateUrl: './path-card.component.html',
  styleUrls: ['./path-card.component.scss']
})
export class PathCardComponent implements OnInit {

  // @Input()
  // pathId : number

  @Input()
  edgeIds : string[]=[];

  public amount: number = 0;
  public shouldShow : boolean = false;
  constructor(public ogmaHandler: OgmaHandlerService) {  }

  ngOnInit(): void {
    // this.findAmount();
  }

  public checkChange(){
    this.changeAppreanceOfEdges();
    this.changeAppreanceOfNodes();
  }
  public changeAppreanceOfEdges(){
    if(this.shouldShow)
    for(let edgeId of this.edgeIds){
      this.ogmaHandler.ogma.getEdge(edgeId).setAttributes({color:"black"});
    }
    else
    for(let edgeId of this.edgeIds){
      this.ogmaHandler.ogma.getEdge(edgeId).setAttributes({color:"gray"});
    }
  }
  public changeAppreanceOfNodes(){
    if(this.shouldShow)
    for(let edgeId of this.edgeIds){
      this.ogmaHandler.ogma.getEdge(edgeId).getSource().setAttributes({color:"black"});
      this.ogmaHandler.ogma.getEdge(edgeId).getTarget().setAttributes({color:"black"});
    }
    else
      for(let edgeId of this.edgeIds){
        this.ogmaHandler.ogma.getEdge(edgeId).getSource().setAttributes({color:"gray"});
        this.ogmaHandler.ogma.getEdge(edgeId).getTarget().setAttributes({color:"gray"});
    }
    this.shouldShow = !this.shouldShow ;

}
}
