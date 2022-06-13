namespace WebTrade.Schema;

public class GraphQLErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.RemoveExtensions().WithMessage(error.Exception.Message);
    }
}
