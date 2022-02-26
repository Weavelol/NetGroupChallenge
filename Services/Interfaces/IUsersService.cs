using DTOModels;


namespace Services.Interfaces {
    /// <summary>
    /// Getting requests from external layer and communicates it to repository layer.
    /// </summary>
    public interface IUsersService {

        /// <summary>
        /// Get All Users from database
        /// </summary>
        /// <returns>info about all users in Database as DTO collection</returns>
        public Task<IEnumerable<ApplicationUserDTO>> GetAllAsync();

        /// <summary>
        /// Update LastLoginDate of user with specified email
        /// </summary>
        /// <param name="userEmail">specified email</param>
        public void UpdateLastLoginDate(string userEmail);
    }
}
