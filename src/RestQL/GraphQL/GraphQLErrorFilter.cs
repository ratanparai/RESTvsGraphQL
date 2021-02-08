using HotChocolate;

namespace RestQL.GraphQL
{
    public class GraphQLErrorFilter
        : IErrorFilter
    {
        public IError OnError(IError error)
        {
            var errorMessage = error.Exception?.Message;
            
            return errorMessage is null 
                ? error 
                : error.WithMessage(errorMessage);
        }
    }
}