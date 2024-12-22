namespace WebStock.Models
{
    public class Exit
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ExitDate { get; set; }
        public double TotalValue { get; set; }
        public ExitType ExitType { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
