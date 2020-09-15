using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;

using Elastic.Communication;

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

        public Node<TTypeData> GetNodeById(TTypeData id)
        {
            return _handler.GetEntity(id, _nodeElasticIndexName) as Node<TTypeData>;
        }

        public IEnumerable<Node<TTypeData>> GetNodesByFilter(string[] filter, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
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