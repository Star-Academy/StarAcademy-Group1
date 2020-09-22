import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-amount-filter',
  templateUrl: './amount-filter.component.html',
  styleUrls: ['./amount-filter.component.scss'],
})
export class AmountFilterComponent implements OnInit {
  minValue: number;
  maxValue: number;
  constructor(public filterService: FilterService) {}

  ngOnInit(): void {}
  public changeChecked() {
    this.filterService.maxAmount = this.maxValue;
    this.filterService.minAmount = this.minValue;
    console.log(this.filterService.maxAmount + " " + this.filterService.minAmount);
  }
}
