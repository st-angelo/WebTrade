namespace WebTrade.Dtos;

public class UpdateSecurityDto
{
    public Guid SecurityId { get; init; }
    public decimal MarketPrice { get; init; }
}
