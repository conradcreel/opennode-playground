namespace OpenNodePlayground.DCA.Domain.Entity;

public class BitcoinPurchase
{
    public string TransactionId { get; set; } = string.Empty;
    public int Satoshis { get; set; }
    public double Fiat { get; set; }
    public DateTime PurchaseDateUtc { get; set; }
}