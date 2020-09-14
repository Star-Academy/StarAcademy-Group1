using System.Collections.Generic;
using MG = Models.GraphStructure;

namespace API.Services.Node
{
    public class Filter
    {

    }

    public interface INodeService<TTypeData>
    {
        MG.Node<TTypeData> GetNodeById(TTypeData id);
        IEnumerable<MG.Node<TTypeData>> GetNodesByFilter(string[] filter, int pageIndex, int pageSize);
        void InsertNode(MG.Node<TTypeData> node);
        void UpdateNode(MG.Node<TTypeData> newNode);
    }
}