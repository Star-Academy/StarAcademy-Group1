using Models;
using Models.Network;
using Models.Response;
using System.Collections.Generic;

namespace API.Services.NodeBusiness
{
    public interface INodeService<TDataModel, TTypeDataId>
    where TDataModel : Entity<TTypeDataId>
    {
        Node<TDataModel, TTypeDataId> GetNodeById(TTypeDataId id);
        IEnumerable<Node<TDataModel, TTypeDataId>> GetNodesById(TTypeDataId[] ids);
        IEnumerable<Node<TDataModel, TTypeDataId>> GetNodesByFilter(
            string[] filter = null,
            Pagination pagination = null
        );
        void InsertNode(Node<TDataModel, TTypeDataId> node);
        void UpdateNode(Node<TDataModel, TTypeDataId> newNode);
        void DeleteNodeById(TTypeDataId id);
    }
}