using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.Network;
using Nest;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.Response;
using Models;


namespace API.Services.EdgeBusiness
{
    public class EdgeService<TDataModel, TTypeDataId, TTypeSideId> : IEdgeService<TDataModel, TTypeDataId, TTypeSideId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        private readonly IEntityHandler<TDataModel, TTypeDataId> _handler;
        private readonly string _edgeElasticIndexName;

        public EdgeService(IConfiguration config, IEntityHandler<TDataModel, TTypeDataId> handler)
        {
            _handler = handler /* TODO: check as NestEntityHandler<TDataModel, TTypeDataId>*/;
            _edgeElasticIndexName = config["TransactionsIndexName"];
        }

        public Edge<TDataModel, TTypeDataId, TTypeSideId> GetEdgeById(TTypeDataId id)
        {
            return new Edge<TDataModel, TTypeDataId, TTypeSideId>(_handler.GetEntity(id, _edgeElasticIndexName));
        }

        public void DeleteEdgeById(TTypeDataId id)
        {
            _handler.DeleteEntity(id, _edgeElasticIndexName);
        }

        public void InsertEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> edge)
        {
            _handler.Insert(edge.Data, _edgeElasticIndexName);
        }

        public void UpdateEdge(Edge<TDataModel, TTypeDataId, TTypeSideId> newEdge)
        {
            _handler.UpdateEntity(newEdge.Data, _edgeElasticIndexName);
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeDataId id, Pagination pagination)
        {
            var queryContainer = (QueryContainer)new MultiMatchQuery
            {
                Fields = new string[] { "source", "target" },
                Query = id as string
            };
            return ((NestElasticHandler<Edge<TDataModel, TTypeDataId, TTypeSideId>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeDataId id)
        {
            var queryContainer = (QueryContainer)new MultiMatchQuery
            {
                Fields = new string[] { "source", "target" },
                Query = id as string
            };
            return ((NestElasticHandler<Entity<TTypeDataId>>)_handler)
                .FetchAllByQuery(queryContainer, _edgeElasticIndexName)
                as IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>>;
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeDataId id, Pagination pagination)
        {
            var queryContainer = new MatchQuery
            {
                Field = "source", // TODO: check toString()
                Query = id as string
            };
            return ((NestElasticHandler<Edge<TDataModel, TTypeDataId, TTypeSideId>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeDataId id, Pagination pagination)
        {
            var queryContainer = new MatchQuery
            {
                Field = "target",
                Query = id.ToString()
            };
            return ((NestElasticHandler<Edge<TDataModel, TTypeDataId, TTypeSideId>>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByFilter(string[] filter, Pagination pagination)
        {
            return ((NestElasticHandler<Edge<TDataModel, TTypeDataId, TTypeSideId>>)_handler).RetrieveQueryDocuments(
                new QueryContainer(),
                _edgeElasticIndexName,
                pagination
            );
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeSideId id, Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeSideId id, Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeSideId id, Pagination pagination)
        {
            throw new System.NotImplementedException();
        }
    }
}