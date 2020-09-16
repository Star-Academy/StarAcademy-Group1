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

        protected string Field { get; set; }
        protected string Operator { get; set; }
        protected string Value { get; set; }

        public abstract QueryContainer Interpret();
    }
}