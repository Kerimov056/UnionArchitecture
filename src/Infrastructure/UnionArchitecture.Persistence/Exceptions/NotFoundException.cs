using System.Net;

namespace UnionArchitecture.Persistence.Exceptions;

public sealed class NotFoundException : Exception, IBaseException
{
    public int StatusCode { get ; set ; }
    public string CustomMessage { get ; set ; }

    public NotFoundException(string message):base(message)
    {
        StatusCode = (int)HttpStatusCode.Conflict;
        CustomMessage = message;
    }
}
