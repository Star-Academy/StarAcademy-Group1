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
    let sd = new Date(+this.startDate);
    let syear = sd.getFullYear();
    let smonth: string = sd.getMonth() < 10 ? `0${sd.getMonth().toString()}` : sd.getMonth().toString();
    let sday: string = sd.getDate() < 10 ? `0${sd.getDate().toString()}` : sd.getDate().toString();
    if (sd.getDay() >= 0)
      this.filterService.startDate = `${syear}-${smonth}-${sday}`;

    let ed = new Date(+this.endDate);
    let eyear = ed.getFullYear();
    let emonth: string = ed.getMonth() < 10 ? `0${ed.getMonth().toString()}` : ed.getMonth().toString();
    let eday: string = ed.getDate() < 10 ? `0${ed.getDate().toString()}` : ed.getDate().toString();
    if (ed.getDay() >= 0)
      this.filterService.endDate = `${eyear}-${emonth}-${eday}`;

    this.filterService.startTime = this.startTime;
    this.filterService.endTime = this.endTime;
    if (this.filterService.startTime){
      this.filterService.startTime += ":00";
    }
    if (this.filterService.endTime){
      this.filterService.endTime += ":00";
    }
    console.log(this.filterService.startDate + " " + this.filterService.endDate + " " + this.filterService.startTime + " " + this.filterService.endTime);
  }
}
