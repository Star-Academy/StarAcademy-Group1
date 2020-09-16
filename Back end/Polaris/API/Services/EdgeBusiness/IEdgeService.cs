using Models;
using Models.Network;
using Models.Response;
using System.Collections.Generic;

namespace API.Services.EdgeBusiness
{
    public interface IEdgeService<TDataModel, TTypeDataId, TTypeSideId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        void InsertEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> edge);
        void UpdateEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> newEdge);
        Edge<TDataModel, TTypeDataId, TTypeSideId> GetEdgeById(TTypeDataId id);
        void DeleteEdgeById(TTypeDataId id);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeSideId id, Pagination pagination = null);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeSideId id, Pagination pagination = null);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeSideId id, Pagination pagination = null);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByFilter(string[] filter = null, Pagination pagination = null);
    }
}