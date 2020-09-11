import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GraphScreenComponent } from './graph-screen/graph-screen.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { RightPanelComponent } from './right-panel/right-panel.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule} from '@angular/material/icon';
import { MatListModule} from '@angular/material/list';
import { MatMenuModule} from '@angular/material/menu';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SelectionsComponent } from './left-panel/selections/selections.component';
import { InformationComponent } from './left-panel/information/information.component';
import { TooltipComponent } from './graph-screen/tooltip/tooltip.component'
import { RandomGraphService } from '../services/read-ogma-from-random-json.service';
import { FormsModule } from '@angular/forms';
import { RightPanelModule } from './right-panel/right-panel.module' ;



@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent,
    RightPanelComponent,
    SearchBarComponent,
    SelectionsComponent,
    InformationComponent,
    GraphScreenComponent,
    TooltipComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMenuModule,
    RightPanelModule
  ],
  exports: [
  RightPanelModule
  ],
  providers: [RandomGraphService],
  bootstrap: [AppComponent]
})
export class AppModule { }
