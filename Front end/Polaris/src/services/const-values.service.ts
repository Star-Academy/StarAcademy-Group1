import { Injectable } from '@angular/core';

@Injectable()
export class ConstValuesService {
    public standardNodeColor : string = "gray";
    public selectedNodeColor : string = "green";
    public inPathNodeColor : string = "black";
    public maxFlowNodeColor : string = "gray";

    public standardEdgeColor : string = "gray";
    public selectedEdgeColor : string = "green";
    public inPathEdgeColor : string = "black";
    public maxFlowEdgeColor : string = "gray";

}
