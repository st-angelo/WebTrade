namespace WebTrade.Dtos;

public class AddTradeDto
{
    public Guid SecurityId { get; init; }
    public Guid UserId { get; init; }
    public decimal Quantity { get; init; }
}
