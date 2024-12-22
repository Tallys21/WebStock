namespace WebStock.Models
{
    public class Adjustment
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public AdjustmentReason AdjustmentReason { get; set; }
    }
}
