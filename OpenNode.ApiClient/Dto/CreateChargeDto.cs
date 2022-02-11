namespace OpenNode.ApiClient.Dto;

public class CreateChargeDto
{
    public string? description { get; set; }
    public double amount { get; set; }
    public string? currency { get; set; }
    public string? customer_email { get; set; }
    public string? notif_email { get; set; }
    public string? customer_name { get; set; }
    public string? order_id { get; set; }
    public string? callback_url { get; set; }
    public string? success_url { get; set; }
    public bool auto_settle { get; set; } = false;
    public int ttl { get; set; } = 1440;
}