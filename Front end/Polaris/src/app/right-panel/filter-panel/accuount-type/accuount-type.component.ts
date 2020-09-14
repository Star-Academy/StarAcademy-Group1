import { Component, Input, OnInit } from '@angular/core';
import {FilterService} from 'src/services/filter.service'

@Component({
  selector: 'app-accuount-type',
  templateUrl: './accuount-type.component.html',
  styleUrls: ['./accuount-type.component.scss']
})
export class AccuountTypeComponent implements OnInit {



  constructor(public filterService : FilterService) { }

  ngOnInit(): void {
  }

  public changeChecked( field:string ,isChecked :boolean){
    let index = this.filterService.accountTypes.indexOf(field, 0);

    if (!isChecked) {
       this.filterService.accountTypes.splice(index, 1);
    }
    else{
      this.filterService.accountTypes.push(field);
    }
    console.log(this.filterService.accountTypes)
  }

}
