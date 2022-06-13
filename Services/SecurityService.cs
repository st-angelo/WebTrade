using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;
using WebTrade.Repositories;

namespace WebTrade.Services;

public class SecurityService : ISecurityService
{
    private readonly IWebTradeRepository _webTradeRepository;
    private readonly ICacheRepository _cacheRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public SecurityService(IWebTradeRepository webTradeRepository, ICacheRepository cacheRepository, ICacheService cacheService, IMapper mapper)
    {
        _webTradeRepository = webTradeRepository;
        _cacheRepository = cacheRepository;
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SecurityDto>> GetAll()
    {
        try
        { 
            return _mapper.Map<IEnumerable<SecurityDto>>(await _cacheRepository.GetSecurities());
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
            Security security = await _cacheRepository.GetSecurity(input.SecurityId);
            Security updatedSecurity = new()
            {
                Id = security.Id,
                Code = security.Code,
                MarketPrice = input.MarketPrice
            };
            await _webTradeRepository.UpdateSecurity(updatedSecurity);

            _cacheService.InvalidateKeys(CacheKey.Securities, Utils.GetCachePrefix(CacheKey.Security, security.Id.ToString()));

            return _mapper.Map<SecurityDto>(updatedSecurity);
        }
        catch (Exception ex)
        {
            // TODO implement handling/logging
            throw new Exception(ex.Message);
        }
    }
}
