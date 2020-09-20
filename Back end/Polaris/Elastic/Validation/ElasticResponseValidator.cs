using Elastic.Exceptions;
using Nest;

namespace Elastic.Validation
{
    public class ElasticResponseValidator
    {
        public static void Validate(IResponse response)
        {
            ValidateServerError(response);
            ValidateClientError(response);
            ValidateApiError(response);
        }

        private static void ValidateServerError(IResponse response)
        {
            var error = response.ServerError;
            if (error != null)
                throw new ElasticServerException(error.ToString());
        }

        private static void ValidateClientError(IResponse response)
        {
            var error = response.OriginalException;
            if (error != null)
                throw new ElasticClientException(error.Message);
        }

        private static void ValidateApiError(IResponse response)
        {
            var error = response.ApiCall.OriginalException;
            if (error != null)
                throw new ElasticApiException(error.Message);
        }
    }
}