namespace WebStock.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Product Product { get; set; }
    }
}
