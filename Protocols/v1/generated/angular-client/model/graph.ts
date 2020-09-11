/**
 * PolarisApi
 * This is the api for Polaris Data Analysis Project on  [PolarisGithub](https://github.com/Star-Academy/StarAcademy-Group2/) 
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { EdgeCollection } from './edgeCollection';
import { NodeCollection } from './nodeCollection';

/**
 * A Set containing unique nodes and unique edges
 */
export interface Graph { 
    nodes?: NodeCollection;
    edges?: EdgeCollection;
}