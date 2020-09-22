import { DataOnScreenService } from './../../../../services/data-on-screen.service';
import { Component, Input, OnInit } from '@angular/core';
import { FilterService } from 'src/services/filter.service';
import * as Branches from '../../../../assets/branches.json';

@Component({
  selector: 'app-branch-filter',
  templateUrl: './branch-filter.component.html',
  styleUrls: ['./branch-filter.component.scss'],
})
export class BranchFilterComponent implements OnInit {
  // @Input()
  public branches: string[] ;
  public selectedBranches: string[] = [];
  public searchedBranches: string[] = [];
  constructor(
    public filterService: FilterService,
  ) {}

  ngOnInit(): void {
    this.branches = JSON.parse(JSON.stringify(Branches)).branches;
    this.searchedBranches = this.branches;

  }


  public updateResult(input: string){

    this.searchedBranches = [];
    this.branches.forEach((element) => {
          this.searchedBranches.push(element);
      });

    let temp : string[]=[];
    for(let i=0 ; i<this.searchedBranches.length ; i++) {
      if (this.searchedBranches[i].indexOf(input) != -1 ){
          temp.push(this.searchedBranches[i]);
          }
      }
     this.searchedBranches = [];
     temp.forEach((element)=>{
        this.searchedBranches.push(element);
        console.log(element);
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
