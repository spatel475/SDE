using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SDE_Server.Domain.Repositories;
using SDE_Server.Hubs;
using SDE_Server.Models.Document;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDE_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IHubContext<ServerHub> _hubContext;
        private readonly DocumentRepository _documentRepository;

        public DocumentsController(IHubContext<ServerHub> hubContext, DocumentRepository documentRepo)
        {
            _hubContext = hubContext;
            _documentRepository = documentRepo;
        }

        [HttpPost("Create")]
        public async Task Create([FromBody] DocumentModel document)
        {
            



            //await _documentRepository.Create(document);

            // idk how/if we want to provide live updates since nothing is listening for it in front-end
            _hubContext.Clients.All.SendAsync("Document");
        }

        [HttpPatch("Update")]
        public async Task Update([FromBody] DocumentModel document)
        {
            await _documentRepository.Update(document);
        }

        [HttpPost("Delete")]
        public async Task Delete(int docId)
        {
            await _documentRepository.Delete(docId);
        }

        [HttpGet("")]
        public async Task<List<DocumentModel>> GetDocumentsByUser(int userId)
        {
            return await _documentRepository.GetDocumentsByUser(userId);
        }
    }
}
