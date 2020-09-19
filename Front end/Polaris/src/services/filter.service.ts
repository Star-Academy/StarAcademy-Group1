import { Injectable } from '@angular/core';

@Injectable()
export class FilterService {
  public startDate: string;
  public endDate: string;
  public startTime: string;
  public endTime: string;
  public minAmount: number;
  public maxAmount: number;
  public accountTypes: string[] = [];
  public name: string;
  public branches: string[] = [];

  public getFilter(): string[] {
    var result = [];

    if (this.startDate) {
      result.push(`Date gte ${this.startDate}`);
    }

    if (this.endDate) {
      result.push(`Date lte ${this.endDate}`);
    }

    if (this.startTime) {
      result.push(`Time gte ${this.startTime}`);
    }

    if (this.endTime) {
      result.push(`Time lte ${this.endTime}`);
    }

    if (this.minAmount) {
      result.push(`Amount gte ${this.minAmount}`);
    }

    if (this.maxAmount) {
      result.push(`Amount lte ${this.maxAmount}`);
    }

    if (this.accountTypes.length != 0) {
      for (let index = 0; index < this.accountTypes.length; index++) {
        result.push(`accountType eq ${this.accountTypes[index]}`);
      }
    }

    if (this.name) {
      result.push(`name cnt ${this.name}`);
    }

    if (this.branches.length != 0) {
      for (let index = 0; index < this.branches.length; index++) {
        result.push(`branch eq ${this.branches[index]}`);
      }
    }

    return result;
  }
}
