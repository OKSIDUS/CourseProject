namespace UserCollection.WebAPI.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public int ItemId { get; set; }
        public ItemModel Item { get; set; } = null!;
    }
}
