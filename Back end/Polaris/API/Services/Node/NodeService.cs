using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;
using Nest;
using System.Linq;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.ResponsePagination;
using MG = Models.GraphStructure;
using Models;

namespace API.Services.Node
{
    public class NodeService<TDataModel, TTypeDataId> : INodeService<TDataModel, TTypeDataId>
    where TDataModel : Entity<TTypeDataId>
    {
        private readonly IEntityHandler<TDataModel, TTypeDataId> _handler;
        private readonly string _nodeElasticIndexName;

        public NodeService(IConfiguration config, IEntityHandler<TDataModel, TTypeDataId> handler)
        {
            _nodeElasticIndexName = config["AccountsIndexName"];
            _handler = handler;
        }

        public void DeleteNodeById(TTypeDataId id)
        {
            _handler.DeleteEntity(id, _nodeElasticIndexName);
        }

        public Node<TDataModel, TTypeDataId> GetNodeById(TTypeDataId id)
        {
            return new MG.Node<TDataModel, TTypeDataId>(_handler.GetEntity(id, _nodeElasticIndexName));
        }

        public IEnumerable<Node<TDataModel, TTypeDataId>> GetNodesByFilter(string[] filter, Pagination pagination)
        {
            var data = ((NestEntityHandler<TDataModel, TTypeDataId>)_handler).RetrieveQueryDocuments(
                new QueryContainer(),
                _nodeElasticIndexName,
                pagination
            );
            return data.Select(d => new Node<TDataModel, TTypeDataId>(d));
        }

        public void InsertNode(Node<TDataModel, TTypeDataId> node)
        {
            _handler.Insert(node.Data, _nodeElasticIndexName);
        }

        public void UpdateNode(Node<TDataModel, TTypeDataId> newNode)
        {
            _handler.UpdateEntity(newNode.Data, _nodeElasticIndexName);
        }
    }
}