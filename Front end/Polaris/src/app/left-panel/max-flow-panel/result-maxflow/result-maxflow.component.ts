import { FilterService } from 'src/services/filter.service';
import { ConstValuesService } from 'src/services/const-values.service';
import { GraphHandlerService } from './../../../services/main-graph.service';
import { Component, OnInit } from '@angular/core';
import { DataOnScreenService } from 'src/services/data-on-screen.service';

@Component({
  selector: 'app-result-maxflow',
  templateUrl: './result-maxflow.component.html',
  styleUrls: ['./result-maxflow.component.scss']
})
export class ResultMaxflowComponent implements OnInit {

  public maxFlow: number = null;
  public edgesToFlow = null;
  constructor(
    public graphHandler: GraphHandlerService,
    private constValues: ConstValuesService,
    private filterService: FilterService,
    public dataOnScreen: DataOnScreenService) {
    graphHandler.flowLoaded.subscribe(() => this.initFlow())
  }

  ngOnInit(): void {
  }

  public initFlow() {
    this.maxFlow = this.graphHandler.maxFlowModel.maxFlowAmount;
    this.edgesToFlow = this.graphHandler.maxFlowModel.edgeToFlow;
  }

  public showFlowOnGraph(isChecked: boolean) {
    this.dataOnScreen.showMaxFlow = isChecked ? true : false ;
    for (let edgeId of this.graphHandler.ogma.getEdges().getId()) {
      if (this.edgesToFlow[edgeId]) {
        let edge = this.graphHandler.ogma.getEdge(edgeId);
        edge.setAttributes({
          color: isChecked ? this.constValues.allEdgesInPathsColor
            : this.constValues.standardEdgeColor, width: 1, text: isChecked ? this.edgesToFlow[edgeId] : null
        });
        edge.getSource().setAttributes({ color: isChecked ? this.constValues.allNodesInPathsColor : this.constValues.standardNodeColor });
        edge.getTarget().setAttributes({ color: isChecked ? this.constValues.allNodesInPathsColor : this.constValues.standardNodeColor });
      }
      else {
        let edge = this.graphHandler.ogma.getEdge(edgeId);
        edge.setAttributes({
          text: isChecked ? '0' : null
        });
      }
    }
    if (this.filterService.sourceId !== "" && this.filterService.targetId !== "") {
      this.graphHandler.ogma.getNode(this.filterService.sourceId).setAttributes(
        { color: isChecked ? this.constValues.sourcetargetColor : this.constValues.standardNodeColor })
      this.graphHandler.ogma.getNode(this.filterService.targetId).setAttributes(
        { color: isChecked ? this.constValues.sourcetargetColor : this.constValues.standardNodeColor })
    }
  }


}
