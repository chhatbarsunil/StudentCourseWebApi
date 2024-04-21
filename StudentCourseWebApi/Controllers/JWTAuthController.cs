using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseCore.Models;
using StudentCourseWebApi.JWTHelper;

namespace StudentCourseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTAuthController : ControllerBase
    {
        private readonly IJWTAuthHelper _jWTAuthHelper;

        public JWTAuthController(IJWTAuthHelper jWTAuthHelper)
        {
            _jWTAuthHelper = jWTAuthHelper;
        }
        [HttpPost("login")]
        public string GenerateJWTToken(SystemUser user)
        {
            return _jWTAuthHelper.GenerateJWTToken(user);
        }
    }
}
