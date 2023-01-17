namespace BookStore.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Brand { get; set; }
        public string Genre { get; set; }
        public int Amount { get; set; }
        public int AmountInCart { get; set; }
        public float Price { get; set; }
        public string CoverUrl { get; set; }
    }
}
