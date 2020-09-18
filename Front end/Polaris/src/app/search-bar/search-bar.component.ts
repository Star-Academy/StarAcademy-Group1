import { GraphHandlerService } from './../services/main-graph.service';
import { Component, OnInit, Input } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { DataOnScreenService } from './../../services/data-on-screen.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss'],
})
export class SearchBarComponent implements OnInit {
  @Input() searchPosition: string = '';

  public placeHolderValue: string = 'جست و جو کنید';
  public searchInput: string;

  public searchIcon = faSearch;

  constructor(
    public dataOnScreen: DataOnScreenService,
    public graphHandler: GraphHandlerService
  ) {}

  ngOnInit(): void {
    if (this.searchPosition === 'branchFilter') {
      this.placeHolderValue = 'شعبه مورد نظر خود را انتخاب کنید';
    }
    if (this.searchPosition === 'selectionPanel') {
      this.placeHolderValue = 'حساب مورد نظر خود را جست و جو کنید';
    }
    if (this.searchPosition === 'mainSearch') {
      this.placeHolderValue = 'در پولاریس جست و جو کنید...';
    }
  }

  onSubmit() {
    this.graphHandler.addNode(this.graphHandler.getNodeByid(this.searchInput));
  }

  public checkChange(query: string) {
    if (this.searchPosition === 'branchFilter') {
      this.dataOnScreen.branchFirstInit = false;
      this.dataOnScreen.updateResult(query);
    }
    if (this.searchPosition === 'selectionPanel') {
      console.log('selection panel change');
    }
    if (this.searchPosition === 'mainSearch') {
      this.searchInput = query;
    }
  }
}
