namespace WebTrade.Entities;

public class Trade
{
    public Trade() { }
    public Trade(Trade trade)
    {
        Id = Guid.NewGuid();
        Price = trade.Price;
        Quantity = trade.Quantity;
        Date = DateTime.Now;
        UserId = trade.UserId;
        SecurityId = trade.SecurityId;
    }

    public Guid Id { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public DateTime Date { get; init; }
    public Guid UserId { get; init; }
    public Guid SecurityId { get; init; }

    // Related entities (NOTE: I'd write it like this with EntityFramework)
    public User User { get; set; }
    public Security Security { get; set; }
}
