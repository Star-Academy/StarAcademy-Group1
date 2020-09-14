using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.GraphStructure;

namespace API.Services.Node
{
    public class NodeService<TTypeData> : INodeService<TTypeData>
    {
        private readonly IConfiguration _config;

        public NodeService(IConfiguration config)
        {
            _config = config;
        }

        public Node<TTypeData> GetNodeById(TTypeData id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Node<TTypeData>> GetNodesByFilter(string[] filter, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public void InsertNode(Node<TTypeData> newNode)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateNode(Node<TTypeData> newNode)
        {
            throw new System.NotImplementedException();
        }
    }
}