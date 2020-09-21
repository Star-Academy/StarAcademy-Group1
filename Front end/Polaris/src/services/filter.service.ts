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
  public sourceId:string;
  public targetId:string;
  public maxLength: string = '7';

  public getNodeFilter(): string[] {
    let result = [];
    if (this.accountTypes.length != 0) {
      let accountTypesResult: string = `accountType eq`;
      for (let item of this.accountTypes) {
        accountTypesResult += ` ${item}`;
      }
      result.push(accountTypesResult);
    }

    if (this.name) {
      result.push(`ownerName cnt ${this.name}`);
    }

    if (this.branches.length != 0) {
      let branchResult: string = `branch eq`;
      for (let item of this.branches) {
        branchResult += ` ${item}`;
      }
      result.push(branchResult);
    }


    return result;

  }
  public getEdgeFilter(): string[] {
    let result = [];
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

    return result;
  }

  public getFilter(): string[] {
    let result = [];

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
      let accountTypesResult: string = `accountType eq`;
      for (let item of this.accountTypes) {
        accountTypesResult += ` ${item}`;
      }
      result.push(accountTypesResult);
    }

    if (this.name) {
      result.push(`ownerName cnt ${this.name}`);
    }

    if (this.branches.length != 0) {
      let branchResult: string = `branch eq`;
      for (let item of this.branches) {
        branchResult += ` ${item}`;
      }
      result.push(branchResult);
    }

    return result;
  }
}
