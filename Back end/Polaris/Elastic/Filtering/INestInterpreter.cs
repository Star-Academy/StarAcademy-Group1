using Nest;

namespace Elastic.Filtering
{
    public interface INestInterpreter
    {
        QueryContainer Interpret(INestInterpretable interpretable);
    }
}