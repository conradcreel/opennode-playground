namespace OpenNode.ApiClient.Dto;

public class InitiateCurrencyExchangeDto
{
    public string to { get; set; } = "btc";
    public double fiat_amount { get; set; }
    public int btc_amount { get; set; }
}