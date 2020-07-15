using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NcNews.Models;

namespace NcNews.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly NcNewsContext _context;

        public UserRepository(NcNewsContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public Users GetUserById(int id)
        {
            return _context.User.Find(id);
        }
        public void PatchUserRecord(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void CreateUser(Users user)
        {
            _context.User.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
