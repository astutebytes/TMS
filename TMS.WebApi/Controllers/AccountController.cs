using AutoMapper;
using TMS.Domain.Entities;
using TMS.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TMS.WebApi.Controllers
{
    public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
                            ITokenService tokenService, IJobService jobService, IMapper mapper) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<object>> Register(RegisterDto registerDto)
        {
            if (!await UserExists(registerDto.Email)) return BadRequest("Account already exists");

            var user = mapper.Map<AppUser>(registerDto);

            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            jobService.EnqueueJob(registerDto.Email); // send confirmation email in the background

            return Ok(new UserDto { 
                FullName = user.FullName, 
                Email= user.Email!, 
                Token = await tokenService.CreateToken(user)});
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return BadRequest("Invalid email / password");

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded)
            {
                var userToReturn = mapper.Map<UserDto>(user);
                userToReturn.Token = await tokenService.CreateToken(user);
                return Ok(userToReturn);
            }

            return BadRequest("Invalid email / password");
        }

        private async Task<bool> UserExists(string email)
        {
            return await userManager.Users.AnyAsync(x => x.Email == email);
        }
    }
}
