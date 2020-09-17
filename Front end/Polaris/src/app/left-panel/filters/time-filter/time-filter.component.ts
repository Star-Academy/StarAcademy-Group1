import { Component, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-time-filter',
  templateUrl: './time-filter.component.html',
  styleUrls: ['./time-filter.component.scss'],
})
export class TimeFilterComponent implements OnInit {
  startClock: string;
  endClock: string;
  startDate: string;
  endDate: string;

  constructor(public filterService: FilterService) {}

  ngOnInit(): void {}
  public changeChecked() {
    console.log('change detected');
    this.filterService.startDate = this.startDate;
    this.filterService.endDate = this.endDate;
    this.filterService.startClock = this.startClock;
    this.filterService.endClock = this.endClock;
  }
}
