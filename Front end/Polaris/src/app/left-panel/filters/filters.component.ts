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
  ) {}

  ngOnInit(): void {}

  sendData(): void {
    if ((this.panel != 'expansion' && this.panel != 'addNode') && (!this.sourceId || !this.targetId)) {
      this.showError();
      return;
    }

    let filtersArray = this.filterService.getFilter();
    switch (this.panel) {
      case 'expansion':
        // expand(filtersArray)
        break;

      case 'path':
        // path(sourceId, targetId, maxLength, filtersArray)
        break;

      case 'flow':
        // flow(sourceId, targetId, filtersArray)
        break;

      case 'addNode':
        let filter: string[] = this.filterService.getFilter();
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
}
