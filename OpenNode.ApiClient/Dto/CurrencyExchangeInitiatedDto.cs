namespace OpenNode.ApiClient.Dto;

public class CurrencyExchangeInitiatedDto
{
    public bool success { get; set; }
    public string id { get; set; } = string.Empty;
    public int btc_amount { get; set; }
    public double fiat_amount { get; set; }
}