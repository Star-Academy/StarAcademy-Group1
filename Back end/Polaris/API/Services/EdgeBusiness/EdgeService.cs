using Microsoft.Extensions.Configuration;
using Nest;
using System.Collections.Generic;
using System.Linq;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models;
using Models.Network;
using Models.Response;
using Elastic.Filtering;

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

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByFilter(string[] filter = null, Pagination pagination = null)
        {
            var data = ((NestEntityHandler<TDataModel, TTypeDataId>)_handler).RetrieveQueryDocuments(
                new NestFilter(filter, GetModelMapping()).Interpret(),
                _edgeElasticIndexName,
                pagination
            );
            return data.Select(d => new Edge<TDataModel, TTypeDataId, TTypeSideId>(d));
        }

        private Dictionary<string, string> GetModelMapping()
        {
            return new Dictionary<string, string>{{"id", "text"}, {"source", "text"}, {"target", "text"},
                {"amount", "numeric"}, {"timestamp", "text"}, {"trackingId", "numeric"}, {"type", "text"}};
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeSideId id, Pagination pagination = null)
        {
            var queryContainer = (QueryContainer)new MultiMatchQuery
            {
                Fields = new string[] { "source", "target" },
                Query = id as string
            };
            var data = ((NestEntityHandler<TDataModel, TTypeDataId>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
            return data.Select(d => new Edge<TDataModel, TTypeDataId, TTypeSideId>(d));
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeSideId id, Pagination pagination = null)
        {
            var queryContainer = new MatchQuery
            {
                Field = "source", // TODO: check toString()
                Query = id as string
            };
            var data = ((NestEntityHandler<TDataModel, TTypeDataId>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
            return data.Select(d => new Edge<TDataModel, TTypeDataId, TTypeSideId>(d));
        }

        public IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeSideId id, Pagination pagination = null)
        {
            var queryContainer = new MatchQuery
            {
                Field = "target",
                Query = id.ToString()
            };
            var data = ((NestEntityHandler<TDataModel, TTypeDataId>)_handler).RetrieveQueryDocuments(
                queryContainer,
                _edgeElasticIndexName,
                pagination
            );
            return data.Select(d => new Edge<TDataModel, TTypeDataId, TTypeSideId>(d));
        }
    }
}