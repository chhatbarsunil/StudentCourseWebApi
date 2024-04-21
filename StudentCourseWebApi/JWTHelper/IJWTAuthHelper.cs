using StudentCourseCore.Models;

namespace StudentCourseWebApi.JWTHelper
{
    public interface IJWTAuthHelper
    {
        public string GenerateJWTToken(SystemUser user);
    }
}
