using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_UserAPI.Models;
using SUT23_UserAPI.Services;
using System.Net.Http;

namespace SUT23_UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepsoitory _userrepo;

        public UserController(IUserRepsoitory uRepo)
        {
            _userrepo = uRepo;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userrepo.GetAllUsers());
        }


        [HttpGet("id")]
        public IActionResult GetSingelUser(int id)
        {
            var u = _userrepo.GetUser(id);
            if(u != null)
            {
                return Ok(u);
            }
            return NotFound($"User with ID {id} Not founded.....");
        }


        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _userrepo.GetUser(id);


            if (userToDelete != null)
            {
                _userrepo.DeleteUSer(userToDelete);
                return Ok();
            }
            return NotFound($"The user with ID {id} is not founded to delete");
        }


        [HttpPost]
        public IActionResult AddNewUser(User newUSer)
        {
            _userrepo.AddUser(newUSer);

            return Created(HttpContext.Request.Scheme + "://" 
                + HttpContext.Request.Host + 
                HttpContext.Request.Path + "/" + newUSer.ID,newUSer);
        }


        [HttpPut("{id}")]
        public IActionResult EditUser(int id, User userToUpdate)
        {
            var existuser = _userrepo.GetUser(id);
            if(existuser != null)
            {
                userToUpdate.ID  = existuser.ID;
                _userrepo.Uppdate(userToUpdate);
            }
            return Ok();
        }
    }
}
