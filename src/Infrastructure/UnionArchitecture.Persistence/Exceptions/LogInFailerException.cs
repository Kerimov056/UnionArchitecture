using System.Net;

namespace UnionArchitecture.Persistence.Exceptions;

public class LogInFailerException : Exception, IBaseException
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public LogInFailerException(string message) :base(message)
    {
        StatusCode =(int)HttpStatusCode.BadRequest;
        CustomMessage = message;
    }
}
