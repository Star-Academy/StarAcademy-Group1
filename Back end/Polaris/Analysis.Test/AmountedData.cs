using Models;

namespace Analysis.Test
{
    class AmountedData : AmountedEntity<int, int>
    {
        public AmountedData(int source, int target, int amount)
        {
            Source = source;
            Target = target;
            Amount = amount;
        }
    }
}
