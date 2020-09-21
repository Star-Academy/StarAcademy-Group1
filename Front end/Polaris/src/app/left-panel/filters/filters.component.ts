import { GraphHandlerService } from './../../services/main-graph.service';
import { Component, Input, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';
import { FilterService } from 'src/services/filter.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss'],
})
export class FiltersComponent implements OnInit {
  @Input()
  panel: string;

  public sourceId: number;
  public targetId: number;
  public maxLength: number; // default = 5

  public hidden = false;
  panelOpenState = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public filterService: FilterService,
    public graphHandler: GraphHandlerService
  ) { }

  ngOnInit(): void { }

  sendData(): void {
    if ((this.panel != 'expansion' && this.panel != 'addNode') && (!this.sourceId || !this.targetId)) {
      this.showError();
      return;
    }
    switch (this.panel) {
      case 'expansion':
        let nodeExpansionFilter: string[] = this.filterService.getNodeFilter();
        let edgeExpansionFilter: string[] = this.filterService.getEdgeFilter();
        this.graphHandler.expandNodes(this.graphHandler.ogma.getSelectedNodes().getId(), nodeExpansionFilter, edgeExpansionFilter);
        break;

      case 'path':
        let nodePathFilter: string[] = this.filterService.getNodeFilter();
        let edgePathFilter: string[] = this.filterService.getEdgeFilter();
        this.graphHandler.findPaths(this.filterService.sourceId, this.filterService.targetId, nodePathFilter, edgePathFilter);
        break;

      case 'flow':
        let nodeFlowFilter: string[] = this.filterService.getNodeFilter();
        let edgeFlowFilter: string[] = this.filterService.getEdgeFilter();
        this.graphHandler.getMaxFlow(this.filterService.sourceId, this.filterService.targetId, nodeFlowFilter, edgeFlowFilter);
        break;

      case 'addNode':
        let filter: string[] = this.filterService.getNodeFilter();
        this.graphHandler.addNodes(filter);
        break;
    }
  }

  private showError() {
    Swal.fire({
      icon: 'error',
      title: 'خطا!',
      text: 'مقادیر خواسته شده را وارد نمایید...',
      confirmButtonText: 'حله',
    });
  }

  public checkChange(field: string, whichField: string) {
    if (whichField === 'sourceId') {
      this.filterService.sourceId = field;
    }
    else if (whichField === 'targetId') {
      this.filterService.targetId = field;
    }
  }
}
