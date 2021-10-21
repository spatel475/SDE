using SDE_Server.Domain.Entities;

namespace SDE_Server.Models
{
    public class OrganizationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


        public Organization MapToEntity()
        {
            return new Organization()
            {
                ID = ID,
                Name = Name,
                Type = Type
            };

        }

        public static OrganizationModel MapFromEntity(Organization entity)
        {
            if (entity == null)
                return null;

            return new OrganizationModel()
            {
                Name = entity.Name,
                ID = entity.ID,
                Type = entity.Type
            };
        }
    }
}
