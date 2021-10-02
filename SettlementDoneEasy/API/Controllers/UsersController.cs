using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SDE_Server.Domain.Entities;
using SDE_Server.Hubs;

namespace SDE_Server.API.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHubContext<ServerHub> _hubContext;
        private readonly sqldbsdedevContext _context;

        public UsersController(sqldbsdedevContext context, IHubContext<ServerHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: Users
        public async Task<string> Index()
        {
            await _hubContext.Clients.All.SendAsync("TestSuccessful", "String coming from SIGNALR HUB");
            return "String coming from CONTROLLER";
        }

    }
}
