using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class ItemOrderViewModel
    {
        [Key]
        public Guid BeverageId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}