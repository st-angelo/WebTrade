using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Repositories;

namespace WebTrade.Services
{
    public class UserService : IUserService
    {
        private readonly ICacheRepository _cacheRepository;
        private readonly IMapper _mapper;

        public UserService(
            ICacheRepository cacheRepository,
            IMapper mapper)
        {
            _cacheRepository = cacheRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<UserDto>>(await _cacheRepository.GetUsers());
            }
            catch (Exception ex)
            {
                // TODO implement handling/logging
                throw new Exception(ex.Message);
            }
        }
    }
}
