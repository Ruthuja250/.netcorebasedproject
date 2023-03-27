using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLoanapi.Contextt;
using HomeLoanapi.Models;
using Microsoft.EntityFrameworkCore;
using HomeLoanapi.Helperss;
using System.Text;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Foundatio.Utility;
using Microsoft.AspNetCore.Authorization;

namespace HomeLoanapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
            private readonly Appdb _authContext;
            public UserController(Appdb appdbContext)
            {
                _authContext = appdbContext;
            }

        // FOR AUTHENTICATING THE USER DETAILS FOR LOGIN
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Users userobj)
        {
            if (userobj == null)
                return BadRequest();
            var user = await _authContext.Userss.FirstOrDefaultAsync(x => x.Email == userobj.Email );
            if (user == null)
                return NotFound(new
                {
                    Message = "User not Found!"
                });
            if (PasswordHasher.VerifyPassword(userobj.Password,user.Password))
            {
                return BadRequest(new
                {
                    Message = "Password is Incorrect"
                });
            }
            user.Token = CreateJwt(user);
            return Ok(new
            {
                Token=user.Token,
                Message = "Login Success!"
            });
        }

        // FOR REGISTERING THE NEW USER
        [HttpPost("register")]

        public async Task<IActionResult> RegisterUsers([FromBody] Users userobj)
        {
            if (userobj == null)
                return BadRequest();
            // Check Email
            if (await CheckUserNameExistAsync(userobj.Email))
                return BadRequest(new { Message = "Email already exist !" });

            //check Password
            var pass = CheckPasswordStrength(userobj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });

            userobj.Password = PasswordHasher.HashPassword(userobj.Password);
            userobj.Role = "User";
            userobj.Token = "";

            await _authContext.Userss.AddAsync(userobj);
            await _authContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Register Success!"
            });

        }
            private Task<bool>CheckUserNameExistAsync(string Email)
            
                => _authContext.Userss.AnyAsync(x => x.Email == Email);
       private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length<8)
            
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
                if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
                    && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be alphanumeric" + Environment.NewLine);
                if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                    sb.Append("password should contain special character" + Environment.NewLine);
                return sb.ToString();
            
        }
        private string CreateJwt(Users user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Name,user.Name)
               
                

            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDiscriptor);
            return jwtTokenHandler.WriteToken(token);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Users>> GetAllUsers()
            {
            return Ok(await _authContext.Userss.ToListAsync());
        }


    }
    

    
}
