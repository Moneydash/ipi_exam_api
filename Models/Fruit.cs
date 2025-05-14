namespace FruitApi.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Fruit(string name, string type, decimal price, int stock) {
            Name = name;
            Type = type;
            Price = price;
            Stock = stock;
        }
    }
}