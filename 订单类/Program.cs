using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> Details { get; set; }

    public Order(int orderId, string customer)
    {
        OrderId = orderId;
        Customer = customer;
        Details = new List<OrderDetails>();
    }

    public override bool Equals(object obj)
    {
        return obj is Order order && OrderId == order.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    public override string ToString()
    {
        return $"OrderId: {OrderId}, Customer: {Customer}, Total Items: {Details.Count}";
    }
}

class OrderDetails
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public OrderDetails(string productName, int quantity, double price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public override bool Equals(object obj)
    {
        return obj is OrderDetails details && ProductName == details.ProductName;
    }

    public override int GetHashCode()
    {
        return ProductName.GetHashCode();
    }

    public override string ToString()
    {
        return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price}";
    }
}

class OrderService
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (!orders.Contains(order))
        {
            orders.Add(order);
        }
        else
        {
            throw new Exception("Order already exists.");
        }
    }

    public void RemoveOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            orders.Remove(order);
        }
        else
        {
            throw new Exception("Order not found.");
        }
    }

    public void ModifyOrder(int orderId, string newCustomer)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            order.Customer = newCustomer;
        }
        else
        {
            throw new Exception("Order not found.");
        }
    }

    public List<Order> QueryOrders(Func<Order, bool> predicate)
    {
        return orders.Where(predicate).OrderBy(o => o.OrderId).ToList();
    }

    public void SortOrders(Comparison<Order> comparison)
    {
        orders.Sort(comparison);
    }
}
