namespace BusinessLogic.Entities;

public class Order
{
    public enum OrderState { Completed, Returned }

    public Guid Id { get; } = Guid.NewGuid();
    public string CreatorUserName { get; }
    public string BuyerFullName { get; }
    public DateTime CreationTime { get; } = DateTime.UtcNow;
    public DateTime? CancellationTime { get; private set; }
    public List<Guid> Bucket { get; } = new List<Guid>();
    public OrderState State { get; private set; } = OrderState.Completed;

    public Order(string creatorUserName, string buyerFullName, List<Guid> bucket)
    {
        CreatorUserName = creatorUserName;
        BuyerFullName = buyerFullName;
        Bucket = bucket;
    }

    public decimal GetBucketPrice()
    {
        decimal totalPrice = 0;
        foreach (Guid itemId in Bucket)
        {
            // Здесь должен быть код получения цены товара из базы данных по его ID
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