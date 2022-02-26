using Services.Interfaces;
using DTOModels;
using Data.Interfaces;
using AutoMapper;

namespace Services.Services {
    /// <inheritdoc/>
    public class UsersService : IUsersService {
        private IUsersRepository usersRepository;
        private IMapper mapper;
        public UsersService(IUsersRepository usersRepository, IMapper mapper) { 
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ApplicationUserDTO>> GetAllAsync() {
            var users = await usersRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ApplicationUserDTO>>(users);
        }

        /// <inheritdoc/>
        public void UpdateLastLoginDate(string userEmail) {
            usersRepository.UpdateLastLoginTime(userEmail);
        }
    }
}
