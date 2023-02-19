namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaMapper
{
    internal static EFEntities.Pizza ToEfPizza(
        this PlaceOrderPizzaDto pIzza) =>
        new EFEntities.Pizza
        {
            PizzaSpecialId = pIzza.PizzaSpecialId,
            Size = pIzza.Size,
            Toppings = pIzza.ToppingsIds
                .Select(pId => new PizzaTopping
                {
                    ToppingId = pId
                }).ToList()
        };

    internal static BusinessObjects.Aggregates.Pizza ToPizza(
        this EFEntities.Pizza pIzza)
    {
        var pizza = new BusinessObjects.Aggregates.Pizza(
            pIzza.PizzaSpecial.ToPizzaSpecial());
        pizza.SetSize(pIzza.Size);
        //if (pizza.Toppings != null)
        //{
        //    foreach (var PizzaTopping in pizza.Toppings)
        //    {
        //        Pizza.AddTopping(PizzaTopping.Topping.ToTopping());
        //    }
        //}
        pIzza.Toppings?
            .ForEach(p => pizza.AddTopping(p.Topping.ToTopping()));
        return pizza;   
    }
}
