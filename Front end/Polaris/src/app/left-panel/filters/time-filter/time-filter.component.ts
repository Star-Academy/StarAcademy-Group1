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
    let startHour;
    let startMinute;
    let endHour;
    let endMinute;
    if (this.startTime) {
      startHour = this.startTime.substr(0, 2);
      startMinute = this.startTime.substr(3, 4);
    }
    if (this.endTime) {
      endHour = this.endTime.substr(0, 2);
      endMinute = this.endTime.substr(3, 4);
    }
    let startTimeUnix = (parseInt(startHour) * 3600) + (parseInt(startMinute) * 60);
    let endTimeUnix = (parseInt(endHour) * 3600) + (parseInt(endMinute) * 60);

    if (Number.isNaN(startTimeUnix)) {
      startTimeUnix = null;
    }
    if (Number.isNaN(endTimeUnix)) {
      endTimeUnix = null;
    }
    console.log(startTimeUnix + " " + endTimeUnix);

    this.filterService.startDate = (+this.startDate) / 1000;
    this.filterService.endDate = (+this.endDate) / 1000;


    this.filterService.startTime = startTimeUnix ? startTimeUnix.toString() : null;
    this.filterService.endTime = endTimeUnix ? endTimeUnix.toString() : null;
  }
}
