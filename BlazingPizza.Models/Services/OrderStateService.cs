namespace BlazingPizza.Models.Services;
public class OrderStateService : IOrderStateService
{
    public Order Order { get; private set; } = new Order();
    public void ReplaceOrder(Order pOrder) => Order = pOrder;
    public void ResetOrder() => Order = new Order();

}
