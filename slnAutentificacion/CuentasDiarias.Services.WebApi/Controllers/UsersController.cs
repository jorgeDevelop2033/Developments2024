using CuentasDiarias.Application.DTO;
using CuentasDiarias.Application.Interface;
using CuentasDiarias.Application.Main;
using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Services.WebApi.Helpers;
using CuentasDiarias.Transversal.Common;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace CuentasDiarias.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly IRolesApplication _rolesApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings, IRolesApplication rolesApplication)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
            _rolesApplication = rolesApplication;
        }

        [Authorize(Roles = "Administrador,Super")]
        [HttpPost("InsertUsers")]
        public IActionResult InsertUsers([FromBody] UsersDTO users)
        {
            var response = _usersApplication.InsertUsers(users);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }

            return BadRequest(response);


        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDTO usersDTO)
        {
            var response = _usersApplication.Authenticate(usersDTO.UserName, usersDTO.Password);


            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }

            return BadRequest(response);
        }

        Claim[] getClaims(Response<UsersDTO> usersDTO, Response<IEnumerable<RolesDTO>> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, usersDTO.Data.UserId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, usersDTO.Data.UserId.ToString()));
            foreach (var item in roles.Data)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Nombre));
            }
            return claims.ToArray();
        }


        private string BuildToken(Response<UsersDTO> usersDTO)
        {
            string secretKey = "mysupersecret_secretkey!123";
            string audience = "Audience";
            string issuer = "Issuer";

            var key = Encoding.UTF8.GetBytes(secretKey);
            var signingCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha512Signature
                                );

            //var tokenHandler = new JwtSecurityTokenHandler();

            var roles = _rolesApplication.GetRolesUsersById(usersDTO.Data.UserId);

            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var subject = new ClaimsIdentity(new[]
            //            {

            //             new Claim(JwtRegisteredClaimNames.Name, usersDTO.Data.FirstName.ToString()),


            //             new Claim(ClaimTypes.Role, roles.Data.FirstOrDefault().Nombre),
            //	new Claim(ClaimTypes.Role, "Administrator2"),

            //});

            var subject = new ClaimsIdentity(
                getClaims(usersDTO, roles)
                );



            var expires = DateTime.UtcNow.AddMinutes(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            ////var tokenDescription = new SecurityTokenDescriptor
            ////{
            ////    Claims = authClaims,
            ////    Expires = DateTime.UtcNow.AddMinutes(5), //cuanto va a durar el token
            ////    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            ////    Issuer =
            ////    Audience = _appSettings.Audience   
            ////};

            //    JwtSecurityToken token = new JwtSecurityToken(
            //       issuer: issuer,
            //       audience: audience,
            //       claims: authClaims,
            //       expires: System.DateTime.UtcNow.AddHours(1),
            //       signingCredentials: signingCredentials
            //   );

            ////var token = tokenHandler.CreateToken(tokenDescription);
            ////var tokenString = tokenHandler.WriteToken(token);

            //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //string writtenToken = handler.WriteToken(token);



            //var token = new JwtSecurityToken(
            //            issuer,
            //            audience,
            //            authClaims,
            //            expires: DateTime.UtcNow.AddMinutes(10),
            //            signingCredentials: signingCredentials);

            //var writtenToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }


    }
}