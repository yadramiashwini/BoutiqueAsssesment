using System;
namespace Boutique
{
    public class Product  //properties 
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }

    public class DeliveryService         //delieveryservice method
    {
        public void PlaceOrder(Product product)
        {
            if (product.Stock <= 0)
            {
                throw new OutOfStockException($"Product {product.Name} is out of stock.");
            }
            Console.WriteLine($"Order placed successfully {product.Stock}");
        }
    }

    public class OutOfStockException : Exception    //custom exception
    {
        private string message { get; set; }
        public OutOfStockException(string message)
        {
            this.message = message;
        }
        public override string Message { get { return message; } }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the product name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter the number of stocks: ");
                int stockQuantity = int.Parse(Console.ReadLine());

                Product product = new Product { Name = productName, Stock = stockQuantity };

                DeliveryService deliveryService = new DeliveryService();
                deliveryService.PlaceOrder(product);
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}