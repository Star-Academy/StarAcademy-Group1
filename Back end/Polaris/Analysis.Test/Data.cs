using Elastic.Models;

namespace Analysis.Test
{
    class Data : Entity<int>
    {
        public Data(int id)
        {
            Id = id;
        }
    }
}
