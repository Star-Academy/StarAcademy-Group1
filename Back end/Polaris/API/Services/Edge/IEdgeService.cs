using System.Collections.Generic;
using MG = Models.GraphStructure;

namespace API.Services.Edge
{
    public class Filter
    {

    }

    public interface IEdgeService<TTypeSide, TTypeData>
    {
        MG.Edge<TTypeSide, TTypeData> GetEdgeById(TTypeData id);
        MG.Edge<TTypeSide, TTypeData> GetEdgeBySourceId(TTypeData id);
        MG.Edge<TTypeSide, TTypeData> GetEdgeByTargetId(TTypeData id);
        MG.Edge<TTypeSide, TTypeData> GetEdgeBySideId(TTypeData id);
        IEnumerable<MG.Edge<TTypeSide, TTypeData>> GetEdgesByFilter(string[] filter, int pageIndex, int pageSize);
        void InsertEdge(MG.Edge<TTypeSide, TTypeData> newEdge);
        void UpdateEdge(MG.Edge<TTypeSide, TTypeData> newEdge);
    }
}