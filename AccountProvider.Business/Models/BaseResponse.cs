namespace AccountProvider.Business.Models;

public abstract class BaseResponse
{
    public int? StatusCode { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
}
