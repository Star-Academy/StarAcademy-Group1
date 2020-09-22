import { Component } from '@angular/core';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Polaris';
  public constructor(public ogmaService:OgmaHandlerService){
  }

}
