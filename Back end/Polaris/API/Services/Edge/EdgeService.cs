using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;

namespace API.Services.Edge
{
    public class EdgeService<TTypeSide, TTypeData> : IEdgeService<TTypeSide, TTypeData>
    {
        private readonly IConfiguration _config;

        public EdgeService(IConfiguration config)
        {
            _config = config;
        }

        public Edge<TTypeSide, TTypeData> GetEdgeById(TTypeData id)
        {
            throw new System.NotImplementedException();
        }

        public Edge<TTypeSide, TTypeData> GetEdgeBySideId(TTypeData id)
        {
            throw new System.NotImplementedException();
        }

        public Edge<TTypeSide, TTypeData> GetEdgeBySourceId(TTypeData id)
        {
            throw new System.NotImplementedException();
        }

        public Edge<TTypeSide, TTypeData> GetEdgeByTargetId(TTypeData id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesByFilter(string[] filter, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public void InsertEdge(Edge<TTypeSide, TTypeData> newEdge)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEdge(Edge<TTypeSide, TTypeData> newEdge)
        {
            throw new System.NotImplementedException();
        }
    }
}