import { Component, Input, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-name-filter',
  templateUrl: './name-filter.component.html',
  styleUrls: ['./name-filter.component.scss'],
})
export class NameFilterComponent implements OnInit {
  constructor(public filterService: FilterService) {}

  ngOnInit(): void {}

  public checkChange(field: string) {
    this.filterService.name = field;
    console.log(this.filterService.name);
  }
}
