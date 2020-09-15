using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;
using Nest;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.ResponsePagination;

namespace API.Services.Node
{
    public class NodeService<TTypeData> : INodeService<TTypeData>
    {
        private readonly IConfiguration _config;
        private readonly IEntityHandler<TTypeData> _handler;
        private readonly string _nodeElasticIndexName;

        public NodeService(IConfiguration config, IEntityHandler<TTypeData> handler)
        {
            _config = config;
            _handler = handler;
            _nodeElasticIndexName = config["AccountsIndexName"];
        }

        public void DeleteNodeById(TTypeData id)
        {
            _handler.DeleteEntity(id, _nodeElasticIndexName);
        }

        public Node<TTypeData> GetNodeById(TTypeData id)
        {
            return _handler.GetEntity(id, _nodeElasticIndexName) as Node<TTypeData>;
        }

        public IEnumerable<Node<TTypeData>> GetNodesByFilter(string[] filter, Pagination pagination)
        {
            return ((NestElasticHandler<Node<TTypeData>>)_handler).RetrieveQueryDocuments(
                new QueryContainer(),
                _nodeElasticIndexName,
                pagination
            );
        }

        public void InsertNode(Node<TTypeData> node)
        {
            _handler.Insert(node, _nodeElasticIndexName);
        }

        public void UpdateNode(Node<TTypeData> newNode)
        {
            _handler.UpdateEntity(newNode, _nodeElasticIndexName);
        }
    }
}