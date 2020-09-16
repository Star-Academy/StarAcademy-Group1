using Nest;

namespace Elastic.Filtering.Criteria
{
    public abstract class NestCriteria : INestInterpretable
    {
        protected NestCriteria(string field, string @operator, string value)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }

        string Field { get; set; }
        string Operator { get; set; }
        string Value { get; set; }

        public abstract QueryContainer Interpret();
    }
}