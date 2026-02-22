using System;
public class OrderService
{
    public void CreateOrder(string productName, int quantity, double price)
    {}
        public void UpdateOrder(string productName, int quantity, double price)
        {
            double totalPrice = quantity * price;
            Console.WriteLine($"Order for {productName} created. Total: {totalPrice}");
        }
    
}