using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using Microsoft.AspNetCore.Http;
using PetAdoptionApp.Models.DTO;
using PetAdoptionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Services
{
    public class UserService : IUserService
    {
        private readonly PetAdoptionAppContext _context;
        public UserService(PetAdoptionAppContext context)
        {
            _context = context;
        }
        
        public async Task<UserClient> CreateNewUser(UserClient user)
        {
            _context.UserClients.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.UserClients.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            _context.UserClients.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
        

        public IEnumerable<UserClient> GetAll()
        {
            return _context.UserClients
                .Include(u => u.ImageIdFkNavigation)
                .Include(u => u.LocationIdFkNavigation)
                .Include(u => u.RollIdFkNavigation)
                .ToList();
        }

        
        public async Task<UserClient> GetUserById(int userId)
        {
            return await _context.UserClients
                .Include(u => u.ImageIdFkNavigation)
                .Include(u => u.LocationIdFkNavigation)
                .Include(u => u.RollIdFkNavigation)
                .SingleOrDefaultAsync(u => u.Id == userId);
        }

        public UserClient UpdateUser(int userId, UserClient user)
        {
            throw new NotImplementedException();
        }

        
    }
}
