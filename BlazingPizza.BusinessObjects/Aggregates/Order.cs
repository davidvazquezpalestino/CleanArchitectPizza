namespace BlazingPizza.BusinessObjects.Aggregates;
public class Order : BaseOrder
{
    public Order()
    {
        PizzasField = new();
    }
    readonly List<Pizza> PizzasField;

    public Address DeliveryAddress { get; private set; }
    public LatLong DeliveryLocation { get; private set; }
    public IReadOnlyCollection<Pizza> Pizzas =>
        PizzasField;

    public void AddPizza(Pizza pIzza) =>
        PizzasField.Add(pIzza);

    public void RemovePizza(Pizza pIzza) =>
        PizzasField.Remove(pIzza);

    public void SetDeliveryAddress(Address pDeliveryAddress) =>
        DeliveryAddress = pDeliveryAddress;

    public void SetDeliveryLocation(LatLong pDeliveryLocation) =>
        DeliveryLocation = pDeliveryLocation;

    public decimal GetTotalPrice() =>
        PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public bool HasPizzas => Pizzas.Any();
}
