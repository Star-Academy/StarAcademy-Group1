import { DataOnScreenService } from './../../../../services/data-on-screen.service';
import { Component, Input, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';

@Component({
  selector: 'app-branch-filter',
  templateUrl: './branch-filter.component.html',
  styleUrls: ['./branch-filter.component.scss'],
})
export class BranchFilterComponent implements OnInit {
  // @Input()
  public branches: string[] = ["آزادی - یادگار", "چهارراه وليعصر", "نازی آباد", "خیابان ایت اله طالقانی", "پاستور",
  "گاندی", "میدان حسین آباد", "امیر آباد شمالی", "احمدیه", "استاد حسن بنا", "جمالزاده جنوبی",
  "شهید صابونیان", "استاد نجات الهی شمالی", "چهارراه نیاکان", "سید خندان", "بیست متری نبرد"];
  public selectedBranches: string[] = [];
  public searchedBranches: string[] = [];
  constructor(
    public filterService: FilterService,
    public dataOnScreen: DataOnScreenService
  ) {}

  ngOnInit(): void {

  }


  public updateResult(input: string){
    let index = this.selectedBranches.indexOf(branch, 0);
    this.searchedBranches = this.branches;
    this.searchedBranches.forEach((element) => {
      console.log(element);
      if (element.indexOf(input) != -1 )
          this.searchedBranches.splice(element);
      });
  }
  public isBranchSelected(branchName : string){
    return this.selectedBranches.indexOf(branchName) === -1 ? false : true ;
  }

  public changeChecked(branch: string, isChecked: boolean) {
    let index = this.selectedBranches.indexOf(branch, 0);

    if (isChecked && index === -1) {
      this.selectedBranches.push(branch)
    }
    else if(!isChecked && index !=-1){
      this.selectedBranches.splice(index, 1);
    }
  }
  public h(){
    console.log("helllo saba $ mahla");
  }
}
