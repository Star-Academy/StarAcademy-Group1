import { Injectable } from '@angular/core';

@Injectable()
export class FilterService {
  public time1: string;
  public time2: string;
  public minAmount :string ;
  public maxAmount :string ;
  public accountTypes :string[] = [];
  public name: string;
  public branches : string[];
}
