using WebTrade.Dtos;
using WebTrade.Services;

namespace WebTrade.Schema;

public class Mutation
{
    public async Task<TradeDto> AddTrade([Service] ITradeService _tradeService, AddTradeDto input)
    {
        return await _tradeService.Add(input);
    }

    public async Task<TradeDto> DeleteTrade([Service] ITradeService _tradeService, Guid id)
    {
        return await _tradeService.Delete(id);
    }

    public async Task<SecurityDto> UpdateSecurity([Service] ISecurityService _securityService, UpdateSecurityDto input)
    {
        return await _securityService.Update(input);
    }
}