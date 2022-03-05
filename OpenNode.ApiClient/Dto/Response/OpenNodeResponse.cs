namespace OpenNode.ApiClient.Dto.Response;

public class OpenNodeResponse<T> where T : new()
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string? ErrorInformation { get; set; }
}