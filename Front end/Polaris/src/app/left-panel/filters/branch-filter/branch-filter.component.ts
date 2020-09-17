import { DataOnScreenService } from './../../../../services/data-on-screen.service';
import { Component, Input, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-branch-filter',
  templateUrl: './branch-filter.component.html',
  styleUrls: ['./branch-filter.component.scss'],
})
export class BranchFilterComponent implements OnInit {
  @Input()
  public branches: string[];

  constructor(
    public filterService: FilterService,
    public dataOnScreen: DataOnScreenService
  ) {}

  ngOnInit(): void {
    this.branches = this.dataOnScreen.branchList;
  }
  public changeChecked(field: string, isChecked: boolean) {
    let index = this.filterService.branches.indexOf(field, 0);

    if (isChecked) {
      this.filterService.branches.push(field);
    } else {
      this.filterService.branches.splice(index, 1);
    }
    console.log(this.filterService.branches);
  }
}
