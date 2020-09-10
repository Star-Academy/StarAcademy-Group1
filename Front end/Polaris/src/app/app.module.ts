import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GraphScreenModule } from './graph-screen/graph-screen.module';
import { SearchBarModule } from './search-bar/search-bar.module';
import { LeftPanelModule } from './left-panel/left-panel.module';
import { RightPanelModule } from './right-panel/right-panel.module';


@NgModule({
  declarations: [
    AppComponent,
    LeftPanelComponent
  ],
  imports: [
    BrowserModule,
    LeftPanelModule,
    RightPanelModule,
    GraphScreenModule,
    SearchBarModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
