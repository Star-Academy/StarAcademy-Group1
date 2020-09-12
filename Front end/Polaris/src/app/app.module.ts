import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GraphScreenComponent } from './graph-screen/graph-screen.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { RightPanelComponent } from './right-panel/right-panel.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatMenuModule} from '@angular/material/menu';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SelectionsComponent } from './left-panel/selections/selections.component';
import { TooltipComponent } from './graph-screen/tooltip/tooltip.component'
import { RandomGraphService } from '../services/read-ogma-from-random-json.service';
import { ComponentsCommunication } from '../services/components-communication.service';
import { FormsModule } from '@angular/forms';
import { FilterPanelComponent } from './right-panel/filter-panel/filter-panel.component';
import { SelectionPanelComponent } from './right-panel/selection-panel/selection-panel.component';
import { ContextMenuComponent } from './graph-screen/context-menu/context-menu.component';
import { InformationPanelComponent } from './left-panel/information-panel/information-panel.component';
import { NodeInfoBoxComponent } from './left-panel/node-info-box/node-info-box.component';




@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent,
    RightPanelComponent,
    SearchBarComponent,
    SelectionsComponent,
    GraphScreenComponent,
    TooltipComponent,
    FilterPanelComponent,
    SelectionPanelComponent,
    ContextMenuComponent,
    InformationPanelComponent,
    NodeInfoBoxComponent,

  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMenuModule,
  ],
  providers: [RandomGraphService,ComponentsCommunication ],
  bootstrap: [AppComponent]
})
export class AppModule { }
