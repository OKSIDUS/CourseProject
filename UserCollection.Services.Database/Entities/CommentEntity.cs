namespace UserCollection.Services.Database.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public int ItemId { get; set; }
        public ItemEntity Item { get; set; } = null!;
    }
}
