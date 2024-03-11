namespace UserCollection.WebAPI.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ItemId {  get; set; }

        public ItemModel Item { get; set; } = null!;


    }
}
