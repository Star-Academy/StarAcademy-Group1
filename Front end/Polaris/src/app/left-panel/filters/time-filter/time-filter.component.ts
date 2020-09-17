import { Component, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-time-filter',
  templateUrl: './time-filter.component.html',
  styleUrls: ['./time-filter.component.scss'],
})
export class TimeFilterComponent implements OnInit {
  startTime: string;
  endTime: string;
  startDate: string;
  endDate: string;

  constructor(public filterService: FilterService) { }

  ngOnInit(): void { }

  public changeChecked() {
    this.filterService.startDate = this.startDate;
    this.filterService.endDate = this.endDate;
    this.filterService.startTime = this.startTime;
    this.filterService.endTime = this.endTime;
  }
}
