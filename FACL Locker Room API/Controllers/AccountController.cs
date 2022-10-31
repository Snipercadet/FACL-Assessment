using FACL_Locker_Room_API.Models;
using FACL_Locker_Room_API.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FACL_Locker_Room_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AccountController(IConfiguration config, IWebHostEnvironment hostEnvironment)
        {
            _config = config;
            _hostEnvironment = hostEnvironment;
        }


        [HttpGet]
        [Route("GetCurrentAppVersion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetCurrentVersion()
        {
            //var appVersion = _config.GetValue<string>("AppVersion:CurrentVersion");
            var appVersion = _config.GetSection("ApiVersion:CurrentVersion").Value;
            return Ok(appVersion);
        }

        [HttpPost]
        [Route("CreateAccount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateAccount([FromBody] CreateAccountDto account )
        {
            if (account == null)
            {
                return BadRequest();
            }

            var wwwRoot = _hostEnvironment.ContentRootPath;
            var fileName = $"{account.FirstName} - {account.LastName}.Json";
            var filePath = string.Format("{0}{1}", wwwRoot, $"\\Account\\{fileName}");
                                   
            if (System.IO.File.Exists(filePath))
            {
                return BadRequest("Account already exist");
            }
            Routines.WriteFile(account, filePath);

            return Ok("Account created");
        }

        [HttpGet]
        [Route("GetAccount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetAccount([FromQuery] GetAccountDto account)
        {
            if (account == null)
            {
                return BadRequest();
            }

            var wwwRoot = _hostEnvironment.ContentRootPath;
            var fileName = $"{account.FirstName} - {account.LastName}.Json";
            var filePath = string.Format("{0}{1}", wwwRoot, $"\\Account\\{fileName}");

            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Invalid credentials");
            }
            var result = Routines.ReadFile(filePath);
            return Ok(result);
        }
    }
}
