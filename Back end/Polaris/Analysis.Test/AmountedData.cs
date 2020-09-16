using Models;
using System;

namespace Analysis.Test
{
    class AmountedData : AmountedEntity<int, int>
    {
        public AmountedData(int source, int target, Int64 amount) : base(source, target, amount)
        {
            
        }
    }
}
