namespace WebTrade.Entities;

public class Trade : BaseEntity
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public Guid SecurityId { get; set; }

    // Related entities (NOTE: I'd write it like this with EntityFramework)
    public User User { get; set; }
    public Security Security { get; set; }
}
