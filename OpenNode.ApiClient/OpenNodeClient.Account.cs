using OpenNode.ApiClient.Dto.Request;
using OpenNode.ApiClient.Dto.Response;

namespace OpenNode.ApiClient;

public partial class OpenNodeClient
{
    public async Task<OpenNodeResponse<GetAccountBalanceResponse>> 
        GetAccountBalance(GetAccountBalanceRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<OpenNodeResponse<GetAccountActivityResponse>> 
        GetAccountActivity(GetAccountActivityRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<OpenNodeResponse<SetScheduledBankWithdrawalsStatusResponse>> 
        SetScheduledBankWithdrawalsStatus(SetScheduledBankWithdrawalsStatusRequest request)
    {
        throw new NotImplementedException();
    }
}