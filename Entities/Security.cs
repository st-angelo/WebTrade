namespace WebTrade.Entities;

public class Security : BaseEntity
{
    public string Code { get; set; }
    public decimal MarketPrice { get; set; }
}
