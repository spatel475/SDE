using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SDE_Server.Domain.Entities;
using SDE_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SDE_Server.Domain.Repositories
{
    public class UserRepository
    {
        private SDEDBContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public UserRepository(SDEDBContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<string> GetAllForTesting()
        {
            return JsonSerializer.Serialize(_dbContext.Users.ToList());
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Select(user => new UserModel
            {
                ID = user.ID,
                Email = user.Email,
                Username = user.Username, 
                Organization = OrganizationModel.MapFromEntity(user.Organization)
            }).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserModel> Create(UserModel user)
        {
            IdentityUser iUser = await CreateIdentityUserAsync(user);
            Users newUser = new()
            {
                Username = user.Username,
                Email = user.Email,
                OrganizationID = user.Organization.ID
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return await GetUserByEmail(user.Email);
        }

        private async Task<IdentityUser> CreateIdentityUserAsync(UserModel user)
        {
            IdentityUser newIdentityUser = new(user.Username)
            {
                Email = user.Email
            };
            IdentityResult createIdentityResult = await _userManager.CreateAsync(newIdentityUser, user.Password);

            if (!createIdentityResult.Succeeded)
            {
                List<string> errorDescriptions = createIdentityResult.Errors.Select(err => err.Description).ToList();
                throw new Exception("CREATE_USER_IDENTITY_EXCEPTION:" + JsonSerializer.Serialize(errorDescriptions));
            }

            return await _userManager.FindByNameAsync(user.Username);
        }
    }
}
