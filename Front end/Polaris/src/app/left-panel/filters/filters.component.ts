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

  public hidden = false;
  panelOpenState = false;
  constructor(
    public componentCommunication: ComponentsCommunicationService,
    public filterService: FilterService
  ) { }

  ngOnInit(): void {
  }

  sendData(): void {
    if (this.panel != "expansion"
      && (!this.sourceId || !this.targetId)) {
      this.showError();
      return;
    }

    let filtersArray = this.filterService.getFilter();
    switch (this.panel) {
      case "expansion":
        // expand(filtersArray)
        break;

      case "path":
        // path(sourceId, targetId, filtersArray)
        break;

      case "flow":
        // flow(sourceId, targetId, filtersArray)
        break;
    }
  }

  private showError() {
    Swal.fire({
      icon: 'error',
      title: 'خطا!',
      text: 'مقادیر خواسته شده را وارد نمایید...',
    })
  }
}
