import { Component } from '@angular/core';
import { GraphHandlerService } from './services/main-graph.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Polaris';
  public constructor(public ogmaService:GraphHandlerService){
  }

}
