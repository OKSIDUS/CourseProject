namespace UserCollection.Services.Database.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ItemsTagsEntity> ItemsTags { get; set; } = new List<ItemsTagsEntity>();
    }
}
