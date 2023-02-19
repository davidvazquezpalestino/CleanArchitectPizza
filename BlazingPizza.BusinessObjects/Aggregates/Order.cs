using BlazingPizza.BusinessObjects.Dtos;

namespace BlazingPizza.BusinessObjects.Aggregates;
public class Order : BaseOrder
{
    public Order()
    {
        PizzasField = new();
    }

    public static Order Create(int pOrderId, DateTime pCreatedTime, 
        string pUserId) 
    {
        Order result = new Order();
        result.Id = pOrderId;
        result.CreatedTime= pCreatedTime;
        result.UserId= pUserId;
        return result;
    }

    readonly List<Pizza> PizzasField;

    public Address DeliveryAddress { get; private set; } =
        new Address("", "", "", "", "", "");
    public LatLong DeliveryLocation { get; private set; } = new();
    public IReadOnlyCollection<Pizza> Pizzas =>
        PizzasField;

    public void AddPizza(Pizza pIzza) =>
        PizzasField.Add(pIzza);

    public Order AddPizzas(IEnumerable<Pizza> pIzzas)
    {
        if (pIzzas != null)
        {
            PizzasField.AddRange(pIzzas);
        }
        return this;
    }

    public void RemovePizza(Pizza pIzza) =>
        PizzasField.Remove(pIzza);

    public Order SetDeliveryAddress(Address pDeliveryAddress)
    {
        DeliveryAddress = pDeliveryAddress;
        return this;
    }

    public Order SetDeliveryLocation(LatLong pDeliveryLocation)
    {
        DeliveryLocation = pDeliveryLocation;
        return this;
    }

    public decimal GetTotalPrice() =>
        PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public bool HasPizzas => Pizzas.Any();

    public static explicit operator PlaceOrderOrderDto(Order pOrder) =>
        new PlaceOrderOrderDto
        {
            UserId= pOrder.UserId,
            DeliveryAddress= pOrder.DeliveryAddress,
            DeliveryLocation= pOrder.DeliveryLocation,
            Pizzas = pOrder.Pizzas.Select(p => (PlaceOrderPizzaDto) p).ToList()
        };
}
