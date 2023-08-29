namespace fast_booze.Entities
{
    public class ItemOrder : BaseEntity
    {
        public virtual Beverage Beverage { get; set; }
        public Guid BeverageId { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;

        public ItemOrder()
        {

        }
        public ItemOrder(Beverage beverage, Guid beverageId, Order order, Guid orderId, int quantity, decimal unitPrice)
        {
            Beverage = beverage;
            BeverageId = beverageId;
            Order = order;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void UpdateAmount(int amount)
        {
            Quantity = amount;
        }
    }
}