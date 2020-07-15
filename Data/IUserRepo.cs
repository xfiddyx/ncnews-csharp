using System;
using System.Collections.Generic;
using NcNews.Models;

namespace NcNews.Data
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUserById(int id);
        void CreateUser(Users user);
        void PatchUserRecord(Users User);
        void Save();
    }
}
