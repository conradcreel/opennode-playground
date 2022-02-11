using OpenNode.ApiClient.Models;
using OpenNode.ApiClient.Dto;

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
}