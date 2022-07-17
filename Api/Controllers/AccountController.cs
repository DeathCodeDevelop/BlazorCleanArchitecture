using Microsoft.AspNetCore.Mvc;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Application.Requests.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AccountController : BaseController
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;

		public AccountController(SignInManager<ApplicationUser> signInManager, 
			UserManager<ApplicationUser> userManager, IConfiguration configuration)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
		}

		private string GenerateToken(TokenRequest request)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, request.Id),
				new Claim(ClaimTypes.Name, request.Username),
			};

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
			  _configuration["Jwt:Audience"],
			  claims,
			  expires: DateTime.Now.AddHours(1),
			  signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult<string>> Login(LoginViewModel model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

			var user = await _userManager.FindByNameAsync(model.UserName);

			var token = new TokenRequest()
			{
				Id = user.Id,
				Username = user.UserName,
			};

			if (result.Succeeded)
				return Ok(GenerateToken(token));

			return BadRequest();
		}

		[HttpPost]
		public async Task<ActionResult<string>> Register(RegisterViewModel model)
		{
			var appUser = new ApplicationUser { UserName = model.UserName };

			var result = await _userManager.CreateAsync(appUser, model.Password);

			if (result.Succeeded)
			{
				//var user = await _userManager.FindByNameAsync(model.UserName);

				//var token = new TokenRequest()
				//{
				//	Id = user.Id,
				//	Username = user.UserName,
				//};

				//return GenerateToken(token);
				return Ok();
			}

			return BadRequest();
		}


		[HttpPost]
		public async Task<ActionResult> Logout(TokenRequest token)
		{
			await _signInManager.SignOutAsync();

			return Ok();
		}
	}
}
