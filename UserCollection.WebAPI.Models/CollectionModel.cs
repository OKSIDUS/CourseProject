using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserCollection.WebAPI.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string UserId { get; set; }

        public ICollection<ItemModel> Items { get; set; } = new List<ItemModel>();

        public CollectionCategoryModel Category { get; set; } = null!;

        public int CategoryId {  get; set; }

        public CustomFieldsModel CustomStringFields { get; set; } = new CustomFieldsModel();

        public CustomFieldsModel CustomIntFields { get; set; } = new CustomFieldsModel();

        public CustomFieldsModel CustomTextFields { get; set; } = new CustomFieldsModel();
        
        public CustomFieldsModel CustomDateTimeFields { get; set; } = new CustomFieldsModel();

        public CustomFieldsModel CustomBoolFilds { get; set; } = new CustomFieldsModel();
    }
}
