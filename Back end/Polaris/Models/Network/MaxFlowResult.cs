using System;
using System.Collections.Generic;

namespace Models.Network
{
    public class MaxFlowResult<TEdgeId> : IModel
    {
        public Int64 MaxFlowAmount { get; set; }
        public Dictionary<TEdgeId, Int64> EdgeToFlow { get; set; }

        public MaxFlowResult()
        {
            EdgeToFlow = new Dictionary<TEdgeId, long>();
        }
    }
}