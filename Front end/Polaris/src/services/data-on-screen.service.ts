import { EventEmitter, Injectable } from '@angular/core';

@Injectable()
export class DataOnScreenService {
    public resultArr;
    public branchFirstInit: boolean = true;
    public nodeViewFirstInit: boolean = true;
    public edgeViewFirstInit: boolean = true;
    public selectedPath : EventEmitter<number>= new EventEmitter<number>() ;
    constructor() {
        this.resultArr = new Array<string>();
        this.selectedPath.emit(-1);
    }
    public branchList: string[] = ["انقلاب","تهران پارس","دیباجی","اندرزگو","طالقانی","ونک","آزادی"];

    public updateResult(query) {
        this.resultArr = new Array<string>();
        this.branchList.map((algo) => {
            if (algo.toLowerCase().indexOf(query.toLowerCase()) != -1) {
                this.resultArr.push(algo);
            }
        });
    }
}
