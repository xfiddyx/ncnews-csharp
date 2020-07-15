using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NcNews.Data;
using NcNews.Models;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using NcNews.Dtos;
using NcNews.Errors;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NcNews.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserController : Controller

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        // GET: /<controller>/
        public ActionResult<IEnumerable<Users>> GetAllUsers()
        {
            var result = _userRepository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<ReadUserDto>>(result));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult GetUserByID(int id)
        {
            var result = _userRepository.GetUserById(id);

            if (result == null)
            {
                return NotFound();
            }
            else return Ok(_mapper.Map<ReadUserDto>(result));

            //errors need sorting - look in to them...
        }

        [HttpPatch("{id}")]
        public ActionResult PatchUserRecord(int id,
            [FromBody] JsonPatchDocument<Users> patchDoc)
        {

            Users user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound(new NotFoundError("This user does not exist"));
            }

            Users userDto = _mapper.Map<Users>(user);

            patchDoc.ApplyTo(userDto);

            _mapper.Map(userDto, user);

            _userRepository.Save();


            return NoContent();

        }

        [HttpPost]
        public ActionResult<ReadUserDto> CreateUser(CreateUserDto createUserDto)
        {
            var users = _mapper.Map<Users>(createUserDto);
            _userRepository.CreateUser(users);
            _userRepository.Save();

            var userReadDto = _mapper.Map<ReadUserDto>(users);

            return CreatedAtRoute(nameof(GetUserByID), new { id = users.id }, userReadDto);
        }

    }
}
