using System.Text.Json.Serialization;
using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<CollectionEntity> UserCollections { get; set; } = new List<CollectionEntity>();
    }
}
