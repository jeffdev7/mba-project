namespace fast_booze.Entities
{
    public class Beverage : BaseEntity
    {
        public string Code { get; set; }
        public string Name    {get;set;}
        public string Brand   {get;set;}
        public decimal Price  {get;set;}

        public Beverage()
        {
            
        }
        public Beverage(string code, string name, string brand, decimal price)
        {
            Code = code;
            Name = name;
            Brand = brand;
            Price = price;
        }
    }
}