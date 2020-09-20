import { Component, OnInit } from '@angular/core';
import { ConstValuesService } from 'src/services/const-values.service';
import { DataOnScreenService } from 'src/services/data-on-screen.service';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-paths-panel',
  templateUrl: './paths-panel.component.html',
  styleUrls: ['./paths-panel.component.scss']
})
export class PathsPanelComponent implements OnInit {


   public paths : string[][][]=[[["10","11"],["9","12"]],[["10","11"],["7"],["8","13"]]];

  constructor(
    public ogmaHandler: OgmaHandlerService ,
    public constValues : ConstValuesService ,
    ) {}

  ngOnInit(): void {
  }
  ngOnDestroy() {

  }
  public updateGraph(){

   for(let groupPaths of this.paths)
    for(let path of groupPaths){
      for(let edgeId of path){
      let edge = this.ogmaHandler.ogma.getEdge(edgeId)
        edge.setAttributes({color : this.constValues.allEdgesInPathsColor });
        edge.getSource().setAttributes({color : this.constValues.allNodesInPathsColor });
        edge.getTarget().setAttributes({color : this.constValues.allNodesInPathsColor });
      }

    }
  }
    public showSelectedPath(id : number){
      if(id!=-1){
      for(let path of this.paths[id])
        for(let edgeId of path){
          let edge = this.ogmaHandler.ogma.getEdge(edgeId)
          edge.setAttributes({color : this.constValues.inPathEdgeColor });
          edge.getSource().setAttributes({color : this.constValues.inPathNodeColor});
          edge.getTarget().setAttributes({color : this.constValues.inPathNodeColor});
        }
      }
        else this.updateGraph();
  }
}


