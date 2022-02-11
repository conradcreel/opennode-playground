using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenNode.ApiClient;

public partial class OpenNodeClient
{
    private const string _ContentType = "application/json";
    private const string _Accept = "application/json";

    private readonly OpenNodeConfiguration _Configuration;
    private readonly HttpClient _HttpClient;

    public OpenNodeClient(OpenNodeConfiguration configuration, HttpClient httpClient)
    {
        _Configuration = configuration;
        _HttpClient = httpClient;
    }

    private JsonSerializerOptions SerializerOptions => new JsonSerializerOptions
    {
        IgnoreReadOnlyFields = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };

    protected async Task<TResponse?> SendPostAsync<TRequest, TResponse>(string url, TRequest? data)
    {
        try
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequestMessage.Headers.Add("Accept", _Accept);
            httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", _Configuration.ApiKey);
            var requestBody = JsonSerializer.Serialize(data, SerializerOptions);

            httpRequestMessage.Content = new StringContent(requestBody, Encoding.UTF8, _ContentType);

            var response = await _HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                return default(TResponse);
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return default(TResponse);
    }

    protected async Task<TResponse?> SendGetAsync<TResponse>(string url)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        httpRequestMessage.Headers.Add("Accept", _Accept);
        httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", _Configuration.ApiKey);

        var response = await _HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);

        if (!response.IsSuccessStatusCode)
        {
            return default(TResponse);
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(responseBody);
    }
}