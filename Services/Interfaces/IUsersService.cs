using DTOModels;

namespace Services.Interfaces {
    public interface IUsersService {
        public Task<IEnumerable<ApplicationUserDTO>> GetAllAsync();
    }
}
