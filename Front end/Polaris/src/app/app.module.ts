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
import { InformationComponent } from './left-panel/information/information.component';
import { TooltipComponent } from './graph-screen/tooltip/tooltip.component'
import { RandomGraphService } from '../services/read-ogma-from-random-json.service';
import { FormsModule } from '@angular/forms';
import { FilterPanelComponent } from './right-panel/filter-panel/filter-panel.component';
import { SelectionPanelComponent } from './right-panel/selection-panel/selection-panel.component';



@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent,
    RightPanelComponent,
    SearchBarComponent,
    SelectionsComponent,
    InformationComponent,
    GraphScreenComponent,
    TooltipComponent,
    FilterPanelComponent,
    SelectionPanelComponent,

  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMenuModule,
  ],
  providers: [RandomGraphService],
  bootstrap: [AppComponent]
})
export class AppModule { }
