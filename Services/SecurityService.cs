using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;
using WebTrade.Repositories;

namespace WebTrade.Services;

public class SecurityService : ISecurityService
{
    private readonly IMapper _mapper;
    private readonly IWebTradeRepository _webTradeRepository;

    public SecurityService(IWebTradeRepository webTradeRepository, IMapper mapper)
    {
        _webTradeRepository = webTradeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SecurityDto>> GetAll()
    {
        try
        { 
            return _mapper.Map<IEnumerable<SecurityDto>>(await _webTradeRepository.GetAllSecurities());
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }

    public async Task<SecurityDto> Update(UpdateSecurityDto input)
    {
        try
        {
            Security security = await _webTradeRepository.GetSecurity(input.SecurityId);
            Security updatedSecurity = new()
            {
                Id = security.Id,
                Code = security.Code,
                MarketPrice = input.MarketPrice
            };
            return _mapper.Map<SecurityDto>(await _webTradeRepository.UpdateSecurity(updatedSecurity));
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }
}
