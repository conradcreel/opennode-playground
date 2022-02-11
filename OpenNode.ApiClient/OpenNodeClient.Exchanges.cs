using OpenNode.ApiClient.Dto;

namespace OpenNode.ApiClient;

public partial class OpenNodeClient
{
    public async Task<CurrencyExchangeInitiatedDto?> InitiateExchangeAsync(InitiateCurrencyExchangeDto exchangeDto)
    {
        var url = $"{_Configuration.BaseUri}/v2/exchanges";

        var response = await SendPostAsync<InitiateCurrencyExchangeDto, CurrencyExchangeInitiatedDto>(url, exchangeDto);

        return response;
    }
}