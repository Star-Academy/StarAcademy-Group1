using System.Collections.Generic;

using Models.ResponsePagination;
using MG = Models.GraphStructure;

namespace API.Services.Node
{
    public class Filter
    {

    }

    public interface INodeService<TTypeData>
    {
        MG.Node<TTypeData> GetNodeById(TTypeData id);
        IEnumerable<MG.Node<TTypeData>> GetNodesByFilter(string[] filter, Pagination pagination);
        void InsertNode(MG.Node<TTypeData> node);
        void UpdateNode(MG.Node<TTypeData> newNode);
        void DeleteNodeById(TTypeData id);
    }
}