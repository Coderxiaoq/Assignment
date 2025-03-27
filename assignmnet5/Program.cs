using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => $"Customer[ID: {Id}, Name: {Name}]";
}

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public override string ToString() => $"Product[ID: {Id}, Name: {Name}, Price: {Price:C}]";
}

public class OrderDetails : IEquatable<OrderDetails>
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Product.Price * Quantity;

    public bool Equals(OrderDetails other) =>
        other != null && Product.Id == other.Product.Id;

    public override bool Equals(object obj) => Equals(obj as OrderDetails);
    public override int GetHashCode() => Product.Id.GetHashCode();
    public override string ToString() =>
        $"{Product} x{Quantity}, Total: {Total:C}";
}

public class Order : IEquatable<Order>
{
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetails> Details { get; } = new List<OrderDetails>();
    public decimal TotalAmount => Details.Sum(d => d.Total);

    public bool Equals(Order other) =>
        other != null && OrderId == other.OrderId;

    public override bool Equals(object obj) => Equals(obj as Order);
    public override int GetHashCode() => OrderId.GetHashCode();
    public override string ToString() =>
        $"Order[ID: {OrderId}]\nCustomer: {Customer}\nDetails:\n{string.Join("\n", Details)}\nTotal: {TotalAmount:C}\n";
}

public class OrderService
{
    private readonly List<Order> _orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (_orders.Contains(order))
            throw new InvalidOperationException("订单已存在");
        if (order.Details.Distinct().Count() != order.Details.Count)
            throw new InvalidOperationException("存在重复订单明细");
        _orders.Add(order);
    }

    public void RemoveOrder(string orderId)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null) throw new KeyNotFoundException("订单不存在");
        _orders.Remove(order);
    }

    public void UpdateOrder(Order newOrder)
    {
        var index = _orders.FindIndex(o => o.OrderId == newOrder.OrderId);
        if (index == -1) throw new KeyNotFoundException("订单不存在");
        _orders[index] = newOrder;
    }

    // LINQ查询方法
    public IEnumerable<Order> QueryByOrderId(string id) =>
        _orders.Where(o => o.OrderId == id).OrderBy(o => o.TotalAmount);

    public IEnumerable<Order> QueryByProduct(string productName) =>
        _orders.Where(o => o.Details.Any(d => d.Product.Name == productName))
              .OrderBy(o => o.TotalAmount);

    public IEnumerable<Order> QueryByCustomer(string customerId) =>
        _orders.Where(o => o.Customer.Id == customerId)
              .OrderBy(o => o.TotalAmount);

    // 排序方法
    public void SortOrders() => _orders.Sort((a, b) => a.OrderId.CompareTo(b.OrderId));

    public List<Order> Get_orders()
    {
        return _orders;
    }

    public void SortOrders(Func<Order, IComparable> keySelector, List<Order> _orders)
    {
        _orders = _orders.OrderBy(keySelector).ToList();
    }
}

class Program
{
    static void Main()
    {
        var service = new OrderService();

        // 创建测试数据
        var customer = new Customer { Id = "C001", Name = "John Doe" };
        var product = new Product { Id = "P100", Name = "Laptop", Price = 5999m };

        var order1 = new Order { OrderId = "O2023001", Customer = customer };
        order1.Details.Add(new OrderDetails { Product = product, Quantity = 2 });

        // 添加订单
        try
        {
            service.AddOrder(order1);
            Console.WriteLine("订单添加成功");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"错误: {ex.Message}");
        }

        // 查询示例
        var results = service.QueryByProduct("Laptop");
        foreach (var order in results)
        {
            Console.WriteLine(order);
        }
    }
}