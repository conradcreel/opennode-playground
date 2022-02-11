using System.Reflection.Emit;
namespace OpenNode.ApiClient.Dto;

public class ChargeCreatedDto
{
    public ChargeData? data { get; set; }
}

public class ChargeData
{
    public string id { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public long created_at { get; set; }
    public string status { get; set; } = string.Empty;
    public double amount { get; set; }
    public string callback_url { get; set; } = string.Empty;
    public string success_url { get; set; } = string.Empty;
    public string order_id { get; set; } = string.Empty;
    public string notes { get; set; } = string.Empty;
    public string currency { get; set; } = string.Empty;
    public double source_fiat_value { get; set; }
    public double fiat_value { get; set; }
    public bool auto_settle { get; set; }
    public LightningInvoice? lightning_invoice { get; set; }
    public OnChainInvoice? chain_invoice { get; set; }
}

public class OnChainInvoice
{
    public string? address { get; set; } = string.Empty;
}

public class LightningInvoice
{
    public long expires_at { get; set; }
    public string? payreq { get; set; } = string.Empty; 
}