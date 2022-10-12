using RestApiClientTemplate.Api.Structures;
using RestApiClientTemplate.Structures;

namespace RestApiClientTemplate.Implementation.Mappers;

internal static class GetResponseMapper
{
    public static ExampletResult ToExampletResult(this GetResponse getResponse)
    {
        return new ExampletResult();
    }
}
