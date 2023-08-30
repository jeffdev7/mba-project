using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class ItemOrderViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BeverageId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}