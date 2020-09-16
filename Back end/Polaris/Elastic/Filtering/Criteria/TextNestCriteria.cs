using Nest;

namespace Elastic.Filtering.Criteria
{
    public class TextNestCriteria : NestCriteria
    {
        public TextNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        public override QueryContainer Interpret()
        {
            throw new System.NotImplementedException();
        }
    }
}