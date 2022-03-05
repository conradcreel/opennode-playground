using OpenNode.ApiClient.Models;
using OpenNode.ApiClient.Dto;
using OpenNode.ApiClient.Dto.Response;
using OpenNode.ApiClient.Dto.Request;

namespace OpenNode.ApiClient;

public partial class OpenNodeClient
{
    public async Task<List<Currency>> GetCurrenciesAsync()
    {
        var url = $"{_Configuration.BaseUri}/v1/currencies";

        var currenciesDto = await SendGetAsync<CurrenciesDto>(url);

        if (currenciesDto?.data == null)
        {
            return new List<Currency>();
        }

        return currenciesDto.data.Select(ticker => new Currency
        {
            Ticker = ticker
        }).ToList();
    }

    public async Task<OpenNodeResponse<GetSupportedCurrenciesResponse>>
        GetSupportedCurrencies(GetSupportedCurrenciesRequest request)
    {
        throw new NotImplementedException();
    }
}