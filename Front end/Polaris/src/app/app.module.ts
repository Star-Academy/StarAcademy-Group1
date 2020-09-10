import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { GraphScreenComponent } from './graph-screen/graph-screen.component';
import { InfoSideBarComponent } from './info-side-bar/info-side-bar.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { RightPanelComponent } from './right-panel/right-panel.component';
import { SearchBarComponent } from './search-bar/search-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    GraphScreenComponent,
    InfoSideBarComponent,
    LeftPanelComponent,
    RightPanelComponent,
    SearchBarComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
