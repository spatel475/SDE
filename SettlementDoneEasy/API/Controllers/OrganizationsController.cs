using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SDE_Server.Domain.Repositories;
using SDE_Server.Hubs;
using SDE_Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDE_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IHubContext<ServerHub> _hubContext;
        private readonly OrganizationRepository _organizationRepository;

        public OrganizationsController(IHubContext<ServerHub> hubContext, OrganizationRepository organizationRepository)
        {
            _hubContext = hubContext;
            _organizationRepository = organizationRepository;
        }

        [HttpGet("")]
        public async Task<List<OrganizationModel>> GetAllOrganizations()
        {
            return await _organizationRepository.GetAll();
        }

    }
}
