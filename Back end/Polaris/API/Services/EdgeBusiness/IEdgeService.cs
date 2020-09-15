using System.Collections.Generic;

using Models;
using Models.GraphStructure;
using Models.ResponsePagination;

namespace API.Services.EdgeBusiness
{
    public interface IEdgeService<TDataModel, TTypeDataId, TTypeSideId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        void InsertEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> edge);
        void UpdateEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> newEdge);
        Edge<TDataModel, TTypeDataId, TTypeSideId> GetEdgeById(TTypeDataId id);
        void DeleteEdgeById(TTypeDataId id);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeSideId id, Pagination pagination);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeSideId id, Pagination pagination);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeSideId id, Pagination pagination);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByFilter(string[] filter, Pagination pagination);
    }
}