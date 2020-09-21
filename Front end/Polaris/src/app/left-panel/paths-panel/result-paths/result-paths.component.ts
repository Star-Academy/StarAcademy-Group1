import { Component, OnInit } from '@angular/core';
import { ConstValuesService } from '../../../../services/const-values.service';
import {GraphHandlerService} from '../../../services/main-graph.service';

@Component({
  selector: 'app-result-paths',
  templateUrl: './result-paths.component.html',
  styleUrls: ['./result-paths.component.scss']
})
export class ResultPathsComponent implements OnInit {
  public paths : string[][][]=[[[]]];
  constructor(
    public ogmaHandler: GraphHandlerService ,
    public constValues : ConstValuesService ,
  ) {ogmaHandler.pathsLoaded.subscribe(()=> this.initPaths()) }

  ngOnInit(): void {
  }
  // ngOnDestroy()
  public initPaths(){
    this.paths = this.ogmaHandler.pathModel.pathsList;
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
   public getPathLenghtById(id : number){
    return this.paths[id].length;
   }
}
