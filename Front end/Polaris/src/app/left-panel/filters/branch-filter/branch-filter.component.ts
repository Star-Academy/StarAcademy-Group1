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

  public selectedBranches: string[]=[];

  constructor(
    public filterService: FilterService,
    public dataOnScreen: DataOnScreenService
  ) {}

  ngOnInit(): void {
    this.branches = this.dataOnScreen.branchList;
  }


  public updateResult(field: string){
  }

  public changeChecked(branch: string, isChecked: boolean) {
    let index = this.selectedBranches.indexOf(branch, 0);

    if (isChecked && index === -1) {
      this.selectedBranches.push(branch)
    }
    else if(!isChecked && index !=-1){
      this.selectedBranches.splice(index, 1);
    }
    console.log(this.selectedBranches);
  }
}
