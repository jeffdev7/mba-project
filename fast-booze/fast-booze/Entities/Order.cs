namespace fast_booze.Entities
{
    public class Order : BaseEntity
    {
       public virtual Customer Customer { get; set; }
       public  Guid CustomerId { get; set; }
       public List<ItemOrder> Itens { get; set; }

        public Order()
        {

        }
        public Order(Customer customer, Guid customerId, List<ItemOrder> itens)
        {
            Customer = customer;
            CustomerId = customerId;
            Itens = itens;
        }
    }
}