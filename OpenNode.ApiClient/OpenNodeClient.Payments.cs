using OpenNode.ApiClient.Dto;

namespace OpenNode.ApiClient;

public partial class OpenNodeClient
{
    public async Task<ChargeCreatedDto?> CreateChargeAsync(CreateChargeDto createChargeDto)
    {
        var url = $"{_Configuration.BaseUri}/v1/charges";

        var response = await SendPostAsync<CreateChargeDto, ChargeCreatedDto>(url, createChargeDto);

        return response;
    }
}