using fast_booze.Entities;
using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class StockViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LiquorStoreId { get; set; }
        public List<Beverage> Beverages { get; set; }
        public int QuantityInStock { get; set; }
        public decimal AveragePrice { get; set; }
        public bool hasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}