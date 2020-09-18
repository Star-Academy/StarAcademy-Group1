using Nest;

namespace Elastic.Filtering
{
    public interface INestInterpretable
    {
        QueryContainer Interpret();
    }
}