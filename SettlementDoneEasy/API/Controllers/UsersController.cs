using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SDE_Server.Domain.Repositories;
using SDE_Server.Hubs;
using SDE_Server.Models;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SDE_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHubContext<ServerHub> _hubContext;
        private readonly UserRepository _userRepository;

        public UsersController(IHubContext<ServerHub> hubContext, UserRepository userRepository)
        {
            _hubContext = hubContext;
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<string> Index()
        {
            await _hubContext.Clients.All.SendAsync("TestSuccessful", "String coming from SIGNALR HUB");
            return await _userRepository.GetAllForTesting();
        }

        [HttpPost("Create")]
        public async Task<UserModel> Create([FromBody] UserModel user)
        {
            return await _userRepository.Create(user);
        }
    }
}
