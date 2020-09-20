import { Injectable } from '@angular/core';

@Injectable()
export class ConstValuesService {
    public standardNodeColor : string = "gray";
    public selectedNodeColor : string = "green";
    public inPathNodeColor : string = "#222831";
    public maxFlowNodeColor : string = "gray";
    public allNodesInPathsColor : string = "#4f8a8b";

    public standardEdgeColor : string = "gray";
    public selectedEdgeColor : string = "green";
    public inPathEdgeColor : string = "#222831";
    public maxFlowEdgeColor : string = "gray";
    public allEdgesInPathsColor : string = "#4f8a8b";
}
