namespace fast_booze.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CEP { get; set; }
        public virtual List<Order> Orders { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string email, string phoneNumber, string cEP, List<Order> orders)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            CEP = cEP;
            Orders = orders;
        }
    }
}