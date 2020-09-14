import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GraphScreenComponent } from './graph-screen/graph-screen.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { RightPanelComponent } from './right-panel/right-panel.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule, MatFormFieldControl } from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SelectionsComponent } from './left-panel/selections/selections.component';
import { TooltipComponent } from './graph-screen/tooltip/tooltip.component'
import { OgmaHandlerService } from '../services/ogma-handler.service';
import { ComponentsCommunicationService } from '../services/components-communication.service';
import { FormsModule } from '@angular/forms';
import { FilterPanelComponent } from './right-panel/filter-panel/filter-panel.component';
import { SelectionPanelComponent } from './right-panel/selection-panel/selection-panel.component';
import { ContextMenuComponent } from './graph-screen/context-menu/context-menu.component';
import { InformationPanelComponent } from './left-panel/information-panel/information-panel.component';
import { NodeInfoBoxComponent } from './left-panel/node-info-box/node-info-box.component';
import { EdgeInfoBoxComponent } from './left-panel/information-panel/edge-info-box/edge-info-box.component';
import { PanelsMenuComponent } from './right-panel/panels-menu/panels-menu.component';
import { TimeFilterComponent } from './right-panel/filter-panel/time-filter/time-filter.component';
import { MatNativeDateModule } from '@angular/material/core';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { Ng5SliderModule } from 'ng5-slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AccuountTypeComponent } from './right-panel/filter-panel/accuount-type/accuount-type.component';
import { NameFilterComponent } from './right-panel/filter-panel/name-filter/name-filter.component';
import { BranchFilterComponent } from './right-panel/filter-panel/branch-filter/branch-filter.component';
import { ItemCardComponent } from './right-panel/selection-panel/item-card/item-card.component';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FilterService } from 'src/services/filter.service';
import { AmountFilterComponent } from './right-panel/filter-panel/amount-filter/amount-filter.component';

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
    EdgeInfoBoxComponent,
    PanelsMenuComponent,
    TimeFilterComponent,
    AccuountTypeComponent,
    NameFilterComponent,
    BranchFilterComponent,
    ItemCardComponent,
    AmountFilterComponent,
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMenuModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    NgxMaterialTimepickerModule,
    MatNativeDateModule,
    Ng5SliderModule,
    MatExpansionModule,
    MatCheckboxModule,
    ScrollingModule
  ],
  providers: [OgmaHandlerService, ComponentsCommunicationService, MatNativeDateModule, FilterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
