using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;
using Nest;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.ResponsePagination;
using Models;


namespace API.Services.Edge
{
    public class EdgeService<TTypeSide, TTypeData> : IEdgeService<TTypeSide, TTypeData>
    {
        private readonly IConfiguration _config;
        private readonly IEntityHandler<TTypeData> _handler;
        private readonly string _edgeElasticIndexName;

        public EdgeService(IConfiguration config, IEntityHandler<TTypeData> handler)
        {
            _config = config;
            _handler = handler as NestEntityHandler<TTypeData>;
            _edgeElasticIndexName = config["TransactionsIndexName"];
        }

        public void InsertEdge(Edge<TTypeSide, TTypeData> edge)
        {
            _handler.Insert(edge, _edgeElasticIndexName);
        }

        public void UpdateEdge(Edge<TTypeSide, TTypeData> newEdge)
        {
            _handler.UpdateEntity(newEdge, _edgeElasticIndexName);
        }

        public Edge<TTypeSide, TTypeData> GetEdgeById(TTypeData id)
        {
            return _handler.GetEntity(id, _edgeElasticIndexName) as Edge<TTypeSide, TTypeData>;
        }

        public void DeleteEdgeById(TTypeData id)
        {
            _handler.DeleteEntity(id, _edgeElasticIndexName);
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesBySideId(TTypeData id, Pagination pagination)
        {
            var queryContainer = (QueryContainer)new MultiMatchQuery
            {
                Fields = new string[] { "source", "target" },
                Query = id as string
            };
            return ((NestElasticHandler<Edge<TTypeSide, TTypeData>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesBySideId(TTypeData id)
        {
            var queryContainer = (QueryContainer)new MultiMatchQuery
            {
                Fields = new string[] { "source", "target" },
                Query = id as string
            };
            return ((NestElasticHandler<Entity<TTypeData>>)_handler)
                .FetchAllByQuery(queryContainer, _edgeElasticIndexName)
                as IEnumerable<Edge<TTypeSide, TTypeData>>;
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesBySourceId(TTypeData id, Pagination pagination)
        {
            var queryContainer = new MatchQuery
            {
                Field = "source", // TODO: check toString()
                Query = id as string
            };
            return ((NestElasticHandler<Edge<TTypeSide, TTypeData>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesByTargetId(TTypeData id, Pagination pagination)
        {
            var queryContainer = new MatchQuery
            {
                Field = "target",
                Query = id.ToString()
            };
            return ((NestElasticHandler<Edge<TTypeSide, TTypeData>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TTypeSide, TTypeData>> GetEdgesByFilter(string[] filter, Pagination pagination)
        {
            return ((NestElasticHandler<Edge<TTypeSide, TTypeData>>)_handler).RetrieveQueryDocuments(
                new QueryContainer(),
                _edgeElasticIndexName,
                pagination
            );
        }
    }
}