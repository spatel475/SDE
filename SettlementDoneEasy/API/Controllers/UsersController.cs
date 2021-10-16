using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SDE_Server.Domain.Repositories;
using SDE_Server.Hubs;
using SDE_Server.Models;

namespace SDE_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
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
            return "String coming from CONTROLLER";
        }

        [HttpPost("Create")]
        public async Task<UserModel> Create([FromBody] UserModel loginModel)
        {
            return await _userRepository.Create(loginModel);

        }
    }
}
