using fast_booze.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class LiquorStoreViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? AdminName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CEP { get; set; }
        public string? CNPJ { get; set; }
        public ESubscriptionStatus SubscriptionStatus { get; set; }
    }
}