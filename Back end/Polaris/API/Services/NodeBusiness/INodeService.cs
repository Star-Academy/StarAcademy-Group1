using System.Collections.Generic;

using Models.Response;
using Models.Network;
using Models;

namespace API.Services.NodeBusiness
{
    public interface INodeService<TDataModel, TTypeDataId>
    where TDataModel : Entity<TTypeDataId>
    {
        Node<TDataModel, TTypeDataId> GetNodeById(TTypeDataId id);
        IEnumerable<Node<TDataModel, TTypeDataId>> GetNodesByFilter(string[] filter, Pagination pagination);
        void InsertNode(Node<TDataModel, TTypeDataId> node);
        void UpdateNode(Node<TDataModel, TTypeDataId> newNode);
        void DeleteNodeById(TTypeDataId id);
    }
}