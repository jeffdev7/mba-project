using fast_booze.Entities;
using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CEP { get; set; }
        public Guid OrderId { get;set; }
    }
}