namespace WebStock.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Category Category { get; set; }

    }
}
