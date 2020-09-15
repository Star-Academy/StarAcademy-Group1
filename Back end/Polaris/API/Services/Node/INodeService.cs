using System.Collections.Generic;

using Models.ResponsePagination;
using MG = Models.GraphStructure;
using Models;

namespace API.Services.Node
{
    public interface INodeService<TDataModel, TTypeDataId>
    where TDataModel : Entity<TTypeDataId>
    {
        MG.Node<TDataModel, TTypeDataId> GetNodeById(TTypeDataId id);
        IEnumerable<MG.Node<TDataModel, TTypeDataId>> GetNodesByFilter(string[] filter, Pagination pagination);
        void InsertNode(MG.Node<TDataModel, TTypeDataId> node);
        void UpdateNode(MG.Node<TDataModel, TTypeDataId> newNode);
        void DeleteNodeById(TTypeDataId id);
    }
}