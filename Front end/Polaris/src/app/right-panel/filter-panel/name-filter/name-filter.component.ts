import { Component, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-name-filter',
  templateUrl: './name-filter.component.html',
  styleUrls: ['./name-filter.component.scss']
})
export class NameFilterComponent implements OnInit {

  public value : string ;
  constructor(public filterService : FilterService) { }

  ngOnInit(): void {
    console.log(this.value)
  }

}
