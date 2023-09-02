﻿namespace BlazingPizza.Shared.BusinessObjects.Aggregates;
public class Order : BaseOrder
{
    public Order()
    {
        PizzasField = new();
    }

    public static Order Create(int orderId, DateTime createdTime,
        string userId)
    {
        Order result = new Order();
        result.Id = orderId;
        result.CreatedTime = createdTime;
        result.UserId = userId;
        return result;
    }

    readonly List<Pizza> PizzasField;

    public Address DeliveryAddress { get; private set; } 
    public LatLong DeliveryLocation { get; private set; } = new();
    public IReadOnlyCollection<Pizza> Pizzas =>
        PizzasField;

    public void AddPizza(Pizza pizza) =>
        PizzasField.Add(pizza);

    public Order AddPizzas(IEnumerable<Pizza> pizzas)
    {
        if (pizzas != null)
        {
            PizzasField.AddRange(pizzas);
        }
        return this;
    }

    public void RemovePizza(Pizza pizza) =>
        PizzasField.Remove(pizza);

    public Order SetDeliveryAddress(Address deliveryAddress)
    {
        DeliveryAddress = deliveryAddress;
        return this;
    }

    public Order SetDeliveryLocation(LatLong deliveryLocation)
    {
        DeliveryLocation = deliveryLocation;
        return this;
    }

    public decimal GetTotalPrice() =>
        PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public bool HasPizzas => Pizzas.Any();

    public static explicit operator PlaceOrderOrderDto(Order order) =>
        new PlaceOrderOrderDto
        {
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress,
            DeliveryLocation = order.DeliveryLocation,
            Pizzas = order.Pizzas.Select(p => (PlaceOrderPizzaDto)p).ToList()
        };

    public static implicit operator Order(GetOrderDto order)
    {
        Order newOrder = Create(order.Id, order.CreatedTime, order.UserId);

        order.Pizzas.ToList().ForEach(p => newOrder.AddPizza(p));
        //foreach(var Item in order.Pizzas)
        //{
        //    NewOrder.AddPizza(Item);
        //}
        return newOrder;
    }
}
