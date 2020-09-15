import { Injectable } from '@angular/core';

@Injectable()
export class FilterService {
  public startDate: string;
  public endDate : string;
  public startClock: string;
  public endClock: string;
  public minAmount :number ;
  public maxAmount :number ;
  public accountTypes :string[] = [];
  public name: string;
  public branches : string[] = [];
}
