using System;

class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }

    public Order(int orderId, string customerName)
    {
        OrderId = orderId;
        CustomerName = customerName;
        Status = "Placed";
    }
}

class OrderManager
{
    public delegate void OrderHandler(Order order);

    public event OrderHandler OrderStatusChanged;

    public void UpdateStatus(Order order, string newStatus)
    {
        order.Status = newStatus;

        Console.WriteLine("\nOrder status updated!");
        Console.WriteLine("Order ID : " + order.OrderId);
        Console.WriteLine("Customer : " + order.CustomerName);
        Console.WriteLine("Status   : " + order.Status);

        OrderStatusChanged?.Invoke(order);
    }
}

class Program
{
    static void SendNotification(Order order)
    {
        Console.WriteLine(
            "Notification: Order " + order.OrderId +
            " is now " + order.Status + ".");
    }

    static void Main()
    {
        Console.Write("Enter order ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Order order = new Order(id, name);
        OrderManager manager = new OrderManager();

        manager.OrderStatusChanged += SendNotification;

        Console.WriteLine("\n--- Order Details ---");
        Console.WriteLine("Order ID : " + order.OrderId);
        Console.WriteLine("Customer : " + order.CustomerName);
        Console.WriteLine("Status   : " + order.Status);

        Console.Write("\nEnter new status: ");
        string status = Console.ReadLine();

        manager.UpdateStatus(order, status);
    }
}