import { GraphHandlerService } from './../services/main-graph.service';
import { DataOnScreenService } from './../../services/data-on-screen.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-real-time-search-bar',
  templateUrl: './real-time-search-bar.component.html',
  styleUrls: ['./real-time-search-bar.component.scss'],
})
export class RealTimeSearchBarComponent implements OnInit {
  searchIcon = faSearch;
  constructor(
    public ogmaProvider: GraphHandlerService,
    public dataOnScreen: DataOnScreenService
  ) {}

  @Output()
  public searched = new EventEmitter<string>();

  public value = '';
  ngOnInit(): void {
    // this.resultArr = this.ogmaProvider.ogma.getNodes().map((element) => {
    //       this.resultArr.push(element.getId());
    //   });
  }
  public checkForEnter(event: KeyboardEvent) {
    this.dataOnScreen.nodeViewFirstInit = false;
    this.dataOnScreen.edgeViewFirstInit = false;
    this.searched.emit(this.value);
  }
}
