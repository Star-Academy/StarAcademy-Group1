import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-amount-filter',
  templateUrl: './amount-filter.component.html',
  styleUrls: ['./amount-filter.component.scss'],
})
export class AmountFilterComponent implements OnInit {
  minValue: number = 50;
  maxValue: number = 200;
  options: Options = {
    floor: 0,
    ceil: 25000000000,
    step: 10,
  };
  constructor(public filterService: FilterService) {}

  ngOnInit(): void {}
  public changeChecked() {
    this.filterService.maxAmount = this.maxValue;
    this.filterService.minAmount = this.minValue;
  }
}
