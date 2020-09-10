import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GraphScreenModule } from './graph-screen/graph-screen.module';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { LeftPanelComponent } from './left-panel/left-panel.component';
import { RightPanelComponent } from './right-panel/right-panel.component';


@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent,
    SearchBarComponent,
    RightPanelComponent
  ],
  imports: [
    BrowserModule,
    GraphScreenModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
