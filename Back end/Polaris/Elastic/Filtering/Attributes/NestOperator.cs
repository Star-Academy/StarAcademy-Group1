namespace Elastic.Filtering.Attributes
{
    public class NestOperator : System.Attribute
    {
        public NestOperator(string abbrv)
        {
            Abbrv = abbrv;
        }

        public string Abbrv { get; }
    }
}