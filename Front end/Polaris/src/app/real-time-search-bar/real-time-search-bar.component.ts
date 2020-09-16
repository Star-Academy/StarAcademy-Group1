import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-real-time-search-bar',
  templateUrl: './real-time-search-bar.component.html',
  styleUrls: ['./real-time-search-bar.component.scss']
})
export class RealTimeSearchBarComponent implements OnInit {


  searchIcon = faSearch;
  constructor(public ogmaProvider: OgmaHandlerService) { }

  @Output()
  public searched = new EventEmitter<string>();

  public value = ''
  ngOnInit(): void {
    // this.resultArr = this.ogmaProvider.ogma.getNodes().map((element) => {
    //       this.resultArr.push(element.getId());
    //   });
    }
    public checkForEnter(event: KeyboardEvent) {
        this.searched.emit(this.value);
    }

}
