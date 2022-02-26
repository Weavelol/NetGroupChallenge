using Core.Models;

namespace Data.Interfaces {
    public interface IUsersRepository {
        /// <summary>
        /// Getting all users from database
        /// </summary>
        /// <returns>All ApplicationUsers containing in database</returns>
        public Task<IEnumerable<ApplicationUser>> GetAllAsync();

        /// <summary>
        /// Updates last login time of user with specified email to DateTime.Now
        /// </summary>
        /// <param name="usersEmail">Email of user which lastLoginTime needs to be updated</param>
        public void UpdateLastLoginTime(string usersEmail);

        /// <summary>
        /// Getting user with specified Id
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <returns>Application user with specified Id</returns>
        public Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
