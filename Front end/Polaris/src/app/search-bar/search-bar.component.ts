import { Component, OnInit } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

  searchIcon = faSearch;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    console.log("submit!");
  }

}


