namespace OpenNode.ApiClient.Dto.Request;

public class SetScheduledBankWithdrawalsStatusRequest : OpenNodeRequest
{
    public override string Route => "/v2/withdrawals/bank/scheduled";
}