namespace UserCollection.Services.Database.Entities
{
    public class ItemsTagsEntity
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public ItemEntity Item { get; set; } = null!;


        public int TagId {  get; set; }
        public TagEntity Tag { get; set; } = null!;
    }
}
