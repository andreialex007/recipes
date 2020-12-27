using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSystem.Common;
using RecipesSystem.Models;

namespace RecipesSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        /// <summary>
        /// Generates new JWT token, which have to be used in order to have access to api resources
        /// </summary>
        /// <param name="request">Request must have valid email and not empty password</param>
        /// <returns>token</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 201)]
        public string Get(AuthenticateRequest request)
        {
            var adminMail = "admin@admin.com";
            if (request.Email == adminMail && request.Password == "123")
            {
                var token = TokenHelper.GetToken(adminMail);
                return token;
            }

            return null;
        }
    }
}
