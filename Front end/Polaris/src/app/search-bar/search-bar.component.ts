import { Component, OnInit, Input } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { DataOnScreenService } from './../../services/data-on-screen.service';


@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  @Input() searchPosition: string = "";

  searchIcon = faSearch;

  constructor(public dataOnScreen: DataOnScreenService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    console.log("submit!");
  }

  public checkChange(field: string) {
    if (this.searchPosition === 'branchFilter') {
      this.dataOnScreen.branchSearch = field;
    }
    if (this.searchPosition === 'selectionPanel') {
      console.log('selection panel change');
    }
    if (this.searchPosition === 'mainSearch') {
      console.log('main search change');
    }

  }

}


