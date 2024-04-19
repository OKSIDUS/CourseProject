namespace UserCollection.WebAPI.Models
{
    public class CollectionPageViewModel
    {
        public List<CollectionModel> Collections { get; set; } = new List<CollectionModel>();
        public int CurrentPage { get; set; }

        public int CountOfPage { get; set; }

    }
}
