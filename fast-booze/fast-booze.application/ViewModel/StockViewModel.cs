using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class StockViewModel
    {
        [Key]
        public Guid LiquorStoreId { get; set; }
        public List<BeverageViewModel> Beverages { get; set; }
        public int QuantityInStock { get; set; }
        public decimal AveragePrice { get; set; }
        public bool hasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
    public class StockListViewModel
    {
        [Key]
        public Guid Id { get; set; }    
        public Guid LiquorStoreId { get; set; }
        public List<BeverageViewModel> Beverages { get; set; }
        public int QuantityInStock { get; set; }
        public decimal AveragePrice { get; set; }
        public bool hasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}