﻿using Core.Models;

namespace Data.Interfaces {
    public interface IUsersRepository {
        public Task<IEnumerable<ApplicationUser>> GetAllAsync();
        public Task UpdateLastLoginTime(string userId);
    }
}
