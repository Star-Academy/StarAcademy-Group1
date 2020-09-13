import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-branch-filter',
  templateUrl: './branch-filter.component.html',
  styleUrls: ['./branch-filter.component.scss']
})
export class BranchFilterComponent implements OnInit {

  @Input()
  public branches: string[] = ["hello","hi","lala","gggg","saba","mahla","halele"];

  constructor() {
   }

  ngOnInit(): void {
  }

}
