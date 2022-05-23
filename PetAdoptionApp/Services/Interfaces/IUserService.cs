using Microsoft.AspNetCore.Mvc;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Services.Interfaces
{
    public interface IUserService 
    {
        IEnumerable<UserClient> GetAll();
        Task<UserClient> GetUserById(int userId);
        Task<UserClient> CreateNewUser(UserClient user);
        UserClient UpdateUser(int userId, UserClient user);
        Task<bool> DeleteUser(int userId);
    }
}
