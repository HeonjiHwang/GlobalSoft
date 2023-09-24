using GlobalSoft.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSoft.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public UserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public List<UserInfo> Get()
        {
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpPost]
        public ActionResult Create(UserInfo user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.UserCode = Guid.NewGuid().ToString();
                    _dataAccessProvider.AddUserRecord(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
