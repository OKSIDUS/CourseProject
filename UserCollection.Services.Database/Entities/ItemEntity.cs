using UserCollection.WebAPI.Models;

namespace UserCollection.Services.Database.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreating { get; set; } = DateTime.Now;

        public int CollectionId { get; set; }
        public CollectionEntity Collection { get; set; } = null!;

        public ICollection<ItemsTagsEntity> ItemsTags { get; set; } = new List<ItemsTagsEntity>();
        public int? CustomIntField1Data { get; set; }
        public int? CustomIntField2Data { get; set; }
        public int? CustomIntField3Data { get; set; }

        public string? CustomStringField1Data { get; set; } = string.Empty;
        public string? CustomStringField2Data { get; set; } = string.Empty;
        public string? CustomStringField3Data { get; set; } = string.Empty;

        public string? CustomTextField1Data { get; set; } = string.Empty;
        public string? CustomTextField2Data { get; set; } = string.Empty;
        public string? CustomTextField3Data { get; set; } = string.Empty;

        public DateTime? CustomDateTimeField1Data { get; set; }
        public DateTime? CustomDateTimeField2Data { get; set; }
        public DateTime? CustomDateTimeField3Data { get; set; }

        public bool? CustomBoolField1Data { get; set; }
        public bool? CustomBoolField2Data { get; set; }
        public bool? CustomBoolField3Data { get; set; }

    }
}
