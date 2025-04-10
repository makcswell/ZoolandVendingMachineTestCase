namespace zooland.Models
{
    public class MainProductConfig
    {

        public class Product
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public int BrandId { get; set; }
            public Brand? Brand { get; set; }
        }

        public class Brand
        {

            public int Id { get; set; }
            public string? Name { get; set; }
            public ICollection<Product>? Products { get; set; } 

        }
        public class Coin
        {
            public int Id { get; set; }
            public decimal Value { get; set; }
            public int Quantity { get; set; }
        }


        public class Order
        {
            public int Id { get; set; }
            public DateTimeOffset OrderDate { get; set; }
            public ICollection<OrderItem>? OrderItems { get; set; }
        }

        public class OrderItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
        }








    }
}
