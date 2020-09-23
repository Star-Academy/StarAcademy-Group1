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

  public sourceId: string;
  public targetId: string;
  public maxLength: number; // default = 7

  public hidden = false;
  panelOpenState = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public filterService: FilterService,
    public graphHandler: GraphHandlerService
  ) {}

  ngOnInit(): void {
  }

  sendData(): void {
    if ((this.panel != 'expansion' && this.panel != 'addNode') && (!this.sourceId || !this.targetId)) {
      this.showError();
      return;
    }
        let nodeFilters: string[] = this.filterService.getNodeFilter();
        let edgeFilters: string[] = this.filterService.getEdgeFilter();

    switch (this.panel) {
      case "expansion":

        this.filterService.clearVars();
        this.graphHandler.expandNodes(this.graphHandler.ogma.getSelectedNodes().getId(), nodeFilters, edgeFilters);
        break;

      case "path":
        this.filterService.clearVars();
        this.graphHandler.findPaths(this.sourceId, this.targetId, nodeFilters, edgeFilters, this.maxLength);
        break;

      case "flow":
        this.filterService.sourceId = this.sourceId;
        this.filterService.targetId = this.targetId;
        this.filterService.clearVars();
        this.graphHandler.getMaxFlow(this.sourceId, this.targetId, nodeFilters, edgeFilters);
        break;

      case "addNode":
        this.filterService.clearVars();
        this.graphHandler.addNodes(nodeFilters);
        break;
    }
  }

  private showError() {
    Swal.fire({
      icon: 'error',
      title: 'خطا!',
      text: 'مقادیر خواسته شده را وارد نمایید...',
      confirmButtonText: 'حله'
    })
  }
}
