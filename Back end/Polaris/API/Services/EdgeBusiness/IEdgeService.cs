using Models;
using Models.Network;
using Models.Response;
using System.Collections.Generic;

namespace API.Services.EdgeBusiness
{
    public interface IEdgeService<TDataModel, TTypeDataId, TTypeSideId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        Edge<TDataModel, TTypeDataId, TTypeSideId> GetEdgeById(TTypeDataId id);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesById(TTypeDataId[] ids);
        void InsertEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> edge);
        void UpdateEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> newEdge);
        void DeleteEdgeById(TTypeDataId id);
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(
            TTypeSideId id,
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(
            TTypeSideId id,
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(
            TTypeSideId id,
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByFilter(
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetIds(
            TTypeSideId[] ids,
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceIds(
            TTypeSideId[] ids,
            string[] filter = null,
            Pagination pagination = null
        );
        IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideIds(
            TTypeSideId[] ids,
            string[] filter = null,
            Pagination pagination = null
        );
    }
}