using System.ComponentModel.DataAnnotations.Schema;

namespace UserCollection.WebAPI.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CollectionId { get; set; }

        public CollectionModel Collection { get; set; } = null!;

        public ICollection<TagModel> Tags { get; set; } = new List<TagModel>();

        public CustomFieldForData<int?> CustomIntFieldData { get; set; } = new CustomFieldForData<int?>();

        public CustomFieldForData<string?> CustomStringFieldData { get; set; } = new CustomFieldForData<string?>();

        public CustomFieldForData<string?> CustomTextFieldData { get; set; } = new CustomFieldForData<string?>();

        public CustomFieldForData<DateTime?> CustomDateTimeFieldData { get; set; } = new CustomFieldForData<DateTime?>();
         
        public CustomFieldForData<bool?> CustomBoolFieldData { get; set; } = new CustomFieldForData<bool?>();
    }
}
