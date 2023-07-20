using System.Net;

namespace UnionArchitecture.Persistence.Exceptions;

public sealed class DublicatedException : Exception, IBaseException
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public DublicatedException(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.Conflict;
        CustomMessage = message;
    }
}
