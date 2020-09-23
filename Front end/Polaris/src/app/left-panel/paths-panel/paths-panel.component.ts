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



  constructor(
    public ogmaHandler: OgmaHandlerService ,
    public constValues : ConstValuesService ,
    ) {}

  ngOnInit(): void {
  }
  ngOnDestroy() {

  }

}


