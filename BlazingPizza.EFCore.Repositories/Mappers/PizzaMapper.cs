namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaMapper
{
    internal static EFEntities.Pizza ToEfPizza(
        this PlaceOrderPizzaDto pizza) =>
        new EFEntities.Pizza
        {
            PizzaSpecialId = pizza.PizzaSpecialId,
            Size = pizza.Size,
            Toppings = pizza.ToppingsIds
                .Select(id => new EFEntities.PizzaTopping
                {
                    ToppingId = id
                }).ToList()
        };

    internal static SharedAggregates.Pizza ToPizza(
        this EFEntities.Pizza pizza)
    {
        Pizza toPizza = new SharedAggregates.Pizza(
            pizza.PizzaSpecial.ToPizzaSpecial());
        toPizza.SetSize(pizza.Size);

        pizza.Toppings?
            .ForEach(p => toPizza.AddTopping(p.Topping.ToTopping()));
        return toPizza;   
    }
}
