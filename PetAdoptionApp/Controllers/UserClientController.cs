using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
using PetAdoptionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Controllers
{
    [Route("PetApi/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IPetService _petService;
        public UserClientController
        (
            IMapper mapper,
            PetAdoptionAppContext context,
            IUserService userService,
            IPetService petService
        )
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
            _petService = petService;
        }

        // GET: PetApi/User
        [HttpGet]
        public async Task<UsersMetaData> GetUsers()
        {
            var users = await _userService.GetAll();
            var usersDTO = _mapper.Map<IEnumerable<UserViewModel>>(users);
            var usersMetaData = new UsersMetaData();
            usersMetaData.Users = usersDTO;
            usersMetaData.Entries = usersDTO.Count();
            return usersMetaData;
        }

        // GET: PetApi/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userPets = await GetUserPets(id);
            var userDTO = _mapper.Map<UserViewModel>(user);
          
            return userDTO;
        }

        // POST: PetApi/User
        [HttpPost]
        //[Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostUser(UserClient user)
        {
            try
            {
                var newUser = await _userService.CreateNewUser(user);
                return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }        
        }

        // PUT: PetApi/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserClient user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: PetApi/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.UserClients.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            _context.UserClients.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //useful methods
        private bool UserExists(int id)
        {
            return _context.UserClients.Any(e => e.Id == id);
        }

        private async Task<ICollection<Pet>> GetUserPets(int id)
        {

            var pets = await _petService.GetAll();
            ICollection<Pet> userPets = pets.Where(p => p.UserIdFk == id).ToList();
            return userPets;
        }
    }
}
