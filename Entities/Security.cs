namespace WebTrade.Entities;

public class Security
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public decimal MarketPrice { get; init; }
}
