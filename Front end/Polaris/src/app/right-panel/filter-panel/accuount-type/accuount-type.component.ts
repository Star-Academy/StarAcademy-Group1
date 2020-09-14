import { Component, Input, OnInit } from '@angular/core';
import {FilterService} from '../../../../../src/services/filter.service'

@Component({
  selector: 'app-accuount-type',
  templateUrl: './accuount-type.component.html',
  styleUrls: ['./accuount-type.component.scss']
})
export class AccuountTypeComponent implements OnInit {

  public get accountTypes (){return this.filterService.accountTypes }


  constructor(public filterService : FilterService) { }

  ngOnInit(): void {
  }

  public changeChecked( field:string ,isChecked :boolean){

    let index = this.accountTypes.indexOf(field, 0);

    if (!isChecked) {
       this.accountTypes.splice(index, 1);
    }
    else{
      this.accountTypes.push(field);

    }
    console.log(this.accountTypes)
  }

}
