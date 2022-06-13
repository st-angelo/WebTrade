using WebTrade.Entities;

namespace WebTrade.Repositories;

public interface IWebTradeRepository
{
    // Trade
    Task<IEnumerable<Trade>> GetAllTrades(Guid? userId = null);
    Task<Trade> AddTrade(Trade trade);
    Task<Trade> DeleteTrade(Guid id);
    // User
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(Guid id);
    // Security
    Task<IEnumerable<Security>> GetAllSecurities();
    Task<Security> GetSecurity(Guid id);
    Task<Security> UpdateSecurity(Security updatedSecurity);
}
