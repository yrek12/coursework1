using BLL.DTO;
using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;

namespace ResumesAndVacancies.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        public IEnumerable<UserDTO> Get()
        {
            return _userService.GetUsers();
        }

        // GET: api/Users/5
        public UserDTO Get(int id)
        {
            return _userService.GetUserByID(id);
        }

        // POST: api/Users
        public void Post([FromBody]UserDTO user)
        {
            _userService.AddUser(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]UserDTO user)
        {
            _userService.Updateuser(id, user);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            _userService.RemoveUserByID(id);
        }
    }
}
