namespace WebStock.Models
{
    public class Entrie
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public double TotalValue { get; set; }
        public EntryType EntryType { get; set; }
        public Product Product { get; set; }
    }
}
