using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;
using WebTrade.Repositories;

namespace WebTrade.Services;

public class TradeService : ITradeService
{
    private readonly IMapper _mapper;
    private readonly IWebTradeRepository _webTradeRepository;

    public TradeService(IWebTradeRepository webTradeRepository, IMapper mapper)
    {
        _webTradeRepository = webTradeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TradeDto>> GetAll(Guid? userId)
    {
        try
        {
            return _mapper.Map<IEnumerable<TradeDto>>(await _webTradeRepository.GetAllTrades(userId));
        }
        catch(Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<PortfolioDto>> GetPortfolios()
    {
        try
        {
            List<PortfolioDto> portfolios = new();

            IEnumerable<Trade> trades = await _webTradeRepository.GetAllTrades();
            IEnumerable<User> users = await _webTradeRepository.GetAllUsers();

            foreach(User user in users)
            {
                decimal purchaseValue = 0m;
                decimal marketValue = 0m;

                foreach(Trade trade in trades.Where(trade => trade.UserId == user.Id))
                {
                    purchaseValue += trade.Price * trade.Quantity;
                    marketValue += trade.Security.MarketPrice * trade.Quantity;
                }

                portfolios.Add(new()
                {
                    HolderName = user.Name,
                    PurchaseValue = purchaseValue,
                    MarketValue = marketValue,
                    PL = marketValue - purchaseValue
                });
            }

            return portfolios;
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }

    public async Task<TradeDto> Add(AddTradeDto input)
    {
        try
        {
            Security security = await _webTradeRepository.GetSecurity(input.SecurityId);
            Trade newTrade = new()
            {
                Price = security.MarketPrice,
                Quantity = input.Quantity,
                UserId = input.UserId,
                SecurityId = input.SecurityId
            };
            return _mapper.Map<TradeDto>(await _webTradeRepository.AddTrade(newTrade));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TradeDto> Delete(Guid id)
    {
        try
        {
            return _mapper.Map<TradeDto>(await _webTradeRepository.DeleteTrade(id));
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }
}
