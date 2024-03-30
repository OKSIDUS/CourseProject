using System.Text.Json.Serialization;

namespace UserCollection.Services.Database.Entities
{
    public class CollectionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public bool IsPrivate { get; set; }
        public ICollection<ItemEntity> Items { get; set; } = new List<ItemEntity>();

        [JsonIgnore]
        public CategoryEntity Category { get; set; } = null!;

        public int CategoryId {  get; set; }
        public bool CustomIntField1State { get; set; }
        public string CustomIntField1Name { get; set; } = string.Empty;

        public bool CustomIntField2State { get; set; }
        public string CustomIntField2Name { get; set; } = string.Empty;

        public bool CustomIntField3State { get; set; }
        public string CustomIntField3Name { get; set; } = string.Empty;

        public bool CustomStringField1State { get; set; }
        public string CustomStringField1Name { get; set; } = string.Empty;

        public bool CustomStringField2State { get; set; }
        public string CustomStringField2Name { get; set; } = string.Empty;

        public bool CustomStringField3State { get; set; }
        public string CustomStringField3Name { get; set; } = string.Empty;

        public bool CustomTextField1State { get; set; }
        public string CustomTextField1Name { get; set; } = string.Empty;

        public bool CustomTextField2State { get; set; }
        public string CustomTextField2Name { get; set; } = string.Empty;

        public bool CustomTextField3State { get; set; }
        public string CustomTextField3Name { get; set; } = string.Empty;

        public bool CustomDateTimeField1State { get; set; }
        public string CustomDateTimeField1Name { get; set; } = string.Empty;

        public bool CustomDateTimeField2State { get; set; }
        public string CustomDateTimeField2Name { get; set; } = string.Empty;

        public bool CustomDateTimeField3State { get; set; }
        public string CustomDateTimeField3Name { get; set; } = string.Empty;

        public bool CustomBoolField1State { get; set; }
        public string CustomBoolField1Name { get; set; } = string.Empty;

        public bool CustomBoolField2State { get; set; }
        public string CustomBoolField2Name { get; set; } = string.Empty;

        public bool CustomBoolField3State { get; set; }
        public string CustomBoolField3Name { get; set; } = string.Empty;
    }
}
