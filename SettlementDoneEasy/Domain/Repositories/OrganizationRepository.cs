using Microsoft.EntityFrameworkCore;
using SDE_Server.Domain.Entities;
using SDE_Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Domain.Repositories
{
    public class OrganizationRepository
    {
        private SDEDBContext _dbContext;

        public OrganizationRepository(SDEDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrganizationModel>> GetAll()
        {
            return await _dbContext.Organization
                .Select(o => new OrganizationModel
                {
                    ID = o.ID,
                    Name = o.Name,
                    Type = o.Type
                })
                .ToListAsync();
        }

    }
}
