
import { Component, OnInit, Input } from '@angular/core';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-edge-card',
  templateUrl: './edge-card.component.html',
  styleUrls: ['./edge-card.component.scss']
})
export class EdgeCardComponent implements OnInit {
  @Input()
  public edgeId: string;
  @Input()
  public isSelected: boolean;

  constructor(public ogmaProvider: OgmaHandlerService) { }

  ngOnInit(): void {
  }
  public changeChecked(isChecked: boolean) {

    if (isChecked)
      this.ogmaProvider.ogma.getNode(this.edgeId).setSelected(true);
    else
      this.ogmaProvider.ogma.getNode(this.edgeId).setSelected(false);

    }
  }

