// using System.Collections.Generic;

// using Models.ResponsePagination;
// using MG = Models.GraphStructure;

// namespace API.Services.Edge
// {
//     public interface IEdgeService<TTypeSide, TTypeData>
//     {
//         void InsertEdge(MG.Edge<TTypeSide, TTypeData> edge);
//         void UpdateEdge(MG.Edge<TTypeSide, TTypeData> newEdge);
//         MG.Edge<TTypeSide, TTypeData> GetEdgeById(TTypeData id);
//         void DeleteEdgeById(TTypeData id);
//         IEnumerable<MG.Edge<TTypeSide, TTypeData>> GetEdgesBySideId(TTypeData id, Pagination pagination);
//         IEnumerable<MG.Edge<TTypeSide, TTypeData>> GetEdgesBySourceId(TTypeData id, Pagination pagination);
//         IEnumerable<MG.Edge<TTypeSide, TTypeData>> GetEdgesByTargetId(TTypeData id, Pagination pagination);
//         IEnumerable<MG.Edge<TTypeSide, TTypeData>> GetEdgesByFilter(string[] filter, Pagination pagination);
//     }
// }