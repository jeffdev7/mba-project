using System.ComponentModel.DataAnnotations;

namespace fast_booze.application.ViewModel
{
    public sealed class BeverageViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}