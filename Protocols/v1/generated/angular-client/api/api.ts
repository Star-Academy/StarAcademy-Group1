export * from './edges.service';
import { EdgesService } from './edges.service';
export * from './graph.service';
import { GraphService } from './graph.service';
export * from './nodes.service';
import { NodesService } from './nodes.service';
export const APIS = [EdgesService, GraphService, NodesService];
