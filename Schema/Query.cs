using WebTrade.Dtos;
using WebTrade.Services;

namespace WebTrade.Schema;

public class Query
{
    public async Task<IEnumerable<TradeDto>> GetTrades([Service] ITradeService _tradeRepository, Guid? userId)
    {
        return await _tradeRepository.GetAll(userId);
    }

    public async Task<IEnumerable<PortfolioDto>> GetPortfolios([Service] ITradeService _tradeRepository)
    {
        return await _tradeRepository.GetPortfolios();
    }

    public async Task<IEnumerable<SecurityDto>> GetSecurities([Service] ISecurityService _securityService)
    {
        return await _securityService.GetAll();
    }
}
