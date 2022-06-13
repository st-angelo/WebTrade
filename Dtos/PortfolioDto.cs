namespace WebTrade.Dtos;

public class PortfolioDto
{
    public string HolderName { get; init; }
    public decimal PurchaseValue { get; init; }
    public decimal MarketValue { get; init; }
    public decimal PL { get; init; }
}
