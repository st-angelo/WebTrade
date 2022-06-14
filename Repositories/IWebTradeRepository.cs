using WebTrade.Entities;

namespace WebTrade.Repositories;

public interface IWebTradeRepository
{
    // Trade
    Task<IEnumerable<Trade>> GetTrades(string filters = null);
    Task<Trade> AddTrade(Trade trade);
    Task<Trade> DeleteTrade(Guid id);
    // User
    Task<IEnumerable<User>> GetUsers(string filters = null);
    Task<User> GetUser(Guid id);
    // Security
    Task<IEnumerable<Security>> GetSecurities(string filters = null);
    Task<Security> GetSecurity(Guid id);
    Task<Security> UpdateSecurity(Security updatedSecurity);
}
