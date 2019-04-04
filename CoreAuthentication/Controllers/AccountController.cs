using CoreAuthentication.DataAccess;
using CoreAuthentication.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly AEContext _usersDb;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        public AccountController(AEContext usersDb, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _usersDb = usersDb;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
        [ActionName("Signup")]
        [HttpPost]
        public async Task<ActionResult> Signup([FromBody]User us)
        {
            var user = _usersDb.Users.SingleOrDefault(u => u.Username == us.Username);
            if (user != null) return StatusCode(409);

            _usersDb.Users.Add(new User
            {
                Username = us.Username,
                Password = _passwordHasher.GenerateIdentityV3Hash(us.Password)
            });

            await _usersDb.SaveChangesAsync();

            return Ok(user);
        }

        [ActionName("Token")]
        [HttpPost]
        public async Task<IActionResult> Token(string username, string password)
        {
            var user = _usersDb.Users.SingleOrDefault(u => u.Username == username);
            if (user == null || !_passwordHasher.VerifyIdentityV3Hash(password, user.Password)) return BadRequest();

            var jwtToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await _usersDb.SaveChangesAsync();

            return Ok(new
            {
                token = jwtToken,
                refreshToken
            });
        }

        [HttpPost]
        public IActionResult Refresh(string token, string refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = "sdafg-asdfg-asas"; //retrieve the refresh token from a data store
            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = _tokenService.GenerateTokenByClaims(principal.Claims);
            var newRefreshToken = "sdafg-asdfg-asas";
            //DeleteRefreshToken(username, refreshToken);
            //SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}