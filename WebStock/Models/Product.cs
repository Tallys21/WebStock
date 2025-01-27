using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebStock.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PurchasePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalePrice { get; set; }

        public int StockQuantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpirationDate { get; set; }

        public Category? Category { get; set; }
        public int CategoryId {  get; set; }

        public string PurchasePriceFormatted => PurchasePrice.ToString("F2", CultureInfo.InvariantCulture);
        public string SalePriceFormatted => SalePrice.ToString("F2", CultureInfo.InvariantCulture);

    }
}
