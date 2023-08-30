namespace fast_booze.Entities
{
    public class Stock : BaseEntity
    {
        public virtual LiquorStore LiquorStore { get; set; }
        public Guid LiquorStoreId { get; set; }
        public List<Beverage> Beverages { get; set; }
        public int QuantityInStock { get; set; }
        public decimal AveragePrice { get; set; }
        public bool hasDiscount { get; set; }
        public decimal Discount { get; set; }

        public Stock()
        {
            
        }

        public Stock(LiquorStore liquorStore, Guid liquorStoreId, List<Beverage> beverages, 
            int quantityInStock, decimal averagePrice, bool hasDiscount, decimal discount)
        {
            LiquorStore = liquorStore;
            LiquorStoreId = liquorStoreId;
            Beverages = beverages;
            QuantityInStock = quantityInStock;
            AveragePrice = averagePrice;
            this.hasDiscount = hasDiscount;
            Discount = discount;
        }
    }
}