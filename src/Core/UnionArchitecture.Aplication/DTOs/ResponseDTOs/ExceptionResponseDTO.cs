namespace UnionArchitecture.Aplication.DTOs.ResponseDTOs;

public class ExceptionResponseDTO
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public ExceptionResponseDTO(int statusCode, string customMessage)
    {
        StatusCode = statusCode;
        CustomMessage = customMessage;
    }
}
