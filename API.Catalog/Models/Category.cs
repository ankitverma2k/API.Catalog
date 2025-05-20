using MongoDbService;

namespace API.Catalog.Models
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid ParentId { get; set; }

        public string? Description { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsPublished { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public string? BreadCumPath { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public string? SeoName { get; set; }

    }
}
