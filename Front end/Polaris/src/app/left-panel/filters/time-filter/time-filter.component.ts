import { Component, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-time-filter',
  templateUrl: './time-filter.component.html',
  styleUrls: ['./time-filter.component.scss']
})
export class TimeFilterComponent implements OnInit {

  time1: string;
  time2: string;
  constructor(public filterService: FilterService) { }

  ngOnInit(): void {
  }
  public changeChecked() {
    this.filterService.startDate = this.time1;
    this.filterService.endDate = this.time2;
    console.log(this.filterService.startDate);
  }
}
