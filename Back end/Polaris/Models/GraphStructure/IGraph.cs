using System.Collections.Generic;

namespace Models.GraphStructure
{
    public interface IGraph<IN, EN, IE, EE>
    where EN : Entity<IN>
    where EE : Entity<IE>
    {
        Dictionary<EN, LinkedList<EN>> Adj{get; set;}

        LinkedList<EN> GetNeighbors(EN node);

        LinkedList<EN> GetNeighbors(IN nodeId);
    }
}