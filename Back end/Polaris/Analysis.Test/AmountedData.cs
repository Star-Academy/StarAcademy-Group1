//In The Name Of GOD

using Models;
using System;

namespace Analysis.Test
{
    public class AmountedData : AmountedEntity<int, int>
    {

        public AmountedData()
        {

        }
        public AmountedData(int source, int target, Int64 amount) : base(source, target, amount)
        {

        }
    }
}
