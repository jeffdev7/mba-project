namespace fast_booze.Entities
{
    public class Stock : BaseEntity
    {
        public virtual LiquorStore LiquorStore { get; set; }
        public Guid LiquorStoreId { get; set; }
        public virtual Beverage Beverage { get; set; }
        public Guid BeverageId { get; set; }
        public int QuantityInStock { get; set; }
        public decimal AveragePrice { get; set; }
        public bool hasDiscount { get; set; }
        public decimal Discount { get; set; }

        public Stock()
        {
            
        }

        public Stock(LiquorStore liquorStore, Guid liquorStoreId, Beverage beverage, 
            Guid beverageId, int quantityInStock, decimal averagePrice, bool hasDiscount, decimal discount)
        {
            LiquorStore = liquorStore;
            LiquorStoreId = liquorStoreId;
            Beverage = beverage;
            BeverageId = beverageId;
            QuantityInStock = quantityInStock;
            AveragePrice = averagePrice;
            this.hasDiscount = hasDiscount;
            Discount = discount;
        }
    }
}