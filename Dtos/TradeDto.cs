namespace WebTrade.Dtos;

public class TradeDto
{
    public Guid TradeId { get; init; }
    public string SecurityCode { get; init; }
    public string TradePrice { get; init; }
    public string TradeQuantity { get; init; }
    public DateTime TradeDate { get; init; }
    public string BuyerName { get; init; }
}
