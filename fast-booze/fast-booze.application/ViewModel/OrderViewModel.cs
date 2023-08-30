using fast_booze.Entities;
using fast_booze.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public  class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<ItemOrder> Items { get; set; }
    }
}