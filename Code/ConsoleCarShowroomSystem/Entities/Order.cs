namespace BusinessLogic.Entities;

public class Order
{
    public enum OrderState { Completed, Returned }

    public Guid Id { get; } = Guid.NewGuid();
    public string CreatorUserName { get; }
    public string BuyerFullName { get; }
    public DateTime CreationTime { get; } = DateTime.UtcNow;
    public DateTime? CancellationTime { get; private set; }
    public Dictionary<Guid, int> Bucket { get; } = new Dictionary<Guid, int>();
    public OrderState State { get; private set; } = OrderState.Completed;

    public decimal Price { get; private set; }

    public Order(string creatorUserName, string buyerFullName, Dictionary<Guid, int> bucket, decimal price)
    {
        CreatorUserName = creatorUserName;
        BuyerFullName = buyerFullName;
        Bucket = bucket;
        Price = price;
    }

    public decimal GetBucketPrice()
    {
        decimal totalPrice = 0;
        foreach (var pair in Bucket)
        {
            
            decimal itemPrice = 100; // пример цены
            totalPrice += itemPrice;
        }
        return totalPrice;
    }

    public void CancelOrder()
    {
        if (State == OrderState.Completed)
        {
            State = OrderState.Returned;
            CancellationTime = DateTime.UtcNow;
        }
        else
        {
            throw new InvalidOperationException("Can only cancel completed orders.");
        }
    }
}