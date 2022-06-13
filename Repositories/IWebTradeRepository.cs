using WebTrade.Entities;

namespace WebTrade.Repositories;

public interface IWebTradeRepository
{
    // Trade
    Task<IEnumerable<Trade>> GetTrades(Guid? userId = null);
    Task<Trade> AddTrade(Trade trade);
    Task<Trade> DeleteTrade(Guid id);
    // User
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(Guid id);
    // Security
    Task<IEnumerable<Security>> GetSecurities();
    Task<Security> GetSecurity(Guid id);
    Task<Security> UpdateSecurity(Security updatedSecurity);
}
