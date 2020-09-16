import { Component, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-time-filter',
  templateUrl: './time-filter.component.html',
  styleUrls: ['./time-filter.component.scss']
})
export class TimeFilterComponent implements OnInit {

  time1: string ;
  time2: string;
  constructor(public filterServerice : FilterService) { }

  ngOnInit(): void {
  }
  public changeChecked(){
    this.filterServerice.startDate = this.time1 ;
    this.filterServerice.endDate = this.time2 ;
    console.log(this.filterServerice.startDate);
  }
}
