using System.ComponentModel.DataAnnotations.Schema;

namespace UserCollection.WebAPI.Models
{
    public class CollectionCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<CollectionModel> UserCollections { get; set; } = new List<CollectionModel>();
    }
}
