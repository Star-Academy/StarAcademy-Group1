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
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { InformationComponent } from './left-panel/information/information.component';
import { RandomGraphService } from '../services/read-ogma-from-random-json.service';
import { HttpClientModule } from '@angular/common/http';
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule, MatFormFieldControl } from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TooltipComponent } from './graph-screen/tooltip/tooltip.component'
import { OgmaHandlerService } from '../services/ogma-handler.service';
import { ComponentsCommunicationService } from '../services/components-communication.service';
import { FormsModule } from '@angular/forms';
import { FiltersComponent } from './left-panel/filters/filters.component';
import { ContextMenuComponent } from './graph-screen/context-menu/context-menu.component';
import { InformationPanelComponent } from './right-panel/information-panel/information-panel.component';
import { NodeInfoBoxComponent } from './right-panel/information-panel/node-info-box/node-info-box.component';
import { EdgeInfoBoxComponent } from './right-panel/information-panel/edge-info-box/edge-info-box.component';
import { PanelsMenuComponent } from './left-panel/panels-menu/panels-menu.component';
import { TimeFilterComponent } from './left-panel/filters/time-filter/time-filter.component';
import { MatNativeDateModule } from '@angular/material/core';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { Ng5SliderModule } from 'ng5-slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AccuountTypeComponent } from './left-panel/filters/accuount-type-filter/accuount-type-filter.component';
import { NameFilterComponent } from './left-panel/filters/name-filter/name-filter.component';
import { BranchFilterComponent } from './left-panel/filters/branch-filter/branch-filter.component';
// import { ItemCardComponent } from './left-panel/selection-panel/item-card/item-card.component';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FilterService } from 'src/services/filter.service';
import { AmountFilterComponent } from './left-panel/filters/amount-filter/amount-filter.component';
import { DataOnScreenService } from './../services/data-on-screen.service';
import { DateAdapter,  MAT_DATE_FORMATS,  MAT_DATE_LOCALE } from '@angular/material/core';
import { MaterialPersianDateAdapter, PERSIAN_DATE_FORMATS } from './shared/material.persian-date.adapter';
import { ExpansionPanelComponent } from './left-panel/expansion-panel/expansion-panel.component';
import { MaxFlowPanelComponent } from './left-panel/max-flow-panel/max-flow-panel.component';
import { PathsPanelComponent } from './left-panel/paths-panel/paths-panel.component';
import { NodesViewPanelComponent } from './right-panel/view-panel/nodes-view-panel/nodes-view-panel.component';
import { EdgesViewPanelComponent } from './right-panel/view-panel/edges-view-panel/edges-view-panel.component';
import { ViewPanelComponent } from './right-panel/view-panel/view-panel.component'

import { MessageService } from './services/message/message.service';
import { EdgeService } from './services/edge/edge.service';
import { GraphService } from './services/graph/graph.service';

@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent,
    RightPanelComponent,
    SearchBarComponent,
    GraphScreenComponent,
    TooltipComponent,
    FiltersComponent,
    ContextMenuComponent,
    InformationPanelComponent,
    NodeInfoBoxComponent,
    EdgeInfoBoxComponent,
    PanelsMenuComponent,
    TimeFilterComponent,
    AccuountTypeComponent,
    NameFilterComponent,
    BranchFilterComponent,
    // ItemCardComponent,
    AmountFilterComponent,
    ExpansionPanelComponent,
    MaxFlowPanelComponent,
    PathsPanelComponent,
    ViewPanelComponent,
    NodesViewPanelComponent,
    EdgesViewPanelComponent
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
    ScrollingModule,
    HttpClientModule
  ],
  providers: [
    OgmaHandlerService,
    ComponentsCommunicationService,
    MatNativeDateModule,
    FilterService,
    DataOnScreenService,
    RandomGraphService,
    MessageService,
    EdgeService,
    GraphService,
    { provide: DateAdapter, useClass: MaterialPersianDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: PERSIAN_DATE_FORMATS }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
