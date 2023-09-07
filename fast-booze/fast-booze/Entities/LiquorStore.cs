using fast_booze.Entities.Enum;

namespace fast_booze.Entities
{
    public class LiquorStore : BaseEntity
    {
        public string Name { get; set; }
        public string? AdminName { get; set; }  
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CEP { get; set; }
        public string? CNPJ { get; set; }
        public ESubscriptionStatus SubscriptionStatus { get; set; }

        public LiquorStore() { }

        public LiquorStore(string name, string? adminName, string email, string phoneNumber, string cEP, 
            string? cNPJ, ESubscriptionStatus subscriptionStatus)
        {
            Name = name;
            AdminName = adminName;
            Email = email;
            PhoneNumber = phoneNumber;
            CEP = cEP;
            CNPJ = cNPJ;
            SubscriptionStatus = subscriptionStatus;
        }
    }
}