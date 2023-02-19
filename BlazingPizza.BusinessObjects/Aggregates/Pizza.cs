using BlazingPizza.BusinessObjects.Dtos;
using BlazingPizza.BusinessObjects.Interfaces.Common;

namespace BlazingPizza.BusinessObjects.Aggregates;
public class Pizza
{
    readonly List<Topping> ToppingsField;

    public Pizza(PizzaSpecial pSpecial)
    {
        Special = pSpecial;
        Size = (int)PizzaSize.Default;
        ToppingsField = new List<Topping>();
    }

    public PizzaSpecial Special { get; }
    public int Size { get; private set; }
    public IReadOnlyCollection<Topping> Toppings => ToppingsField;

    public void SetSize(int pSize) => Size = pSize;

    public void AddTopping(Topping pTopping)
    {
        if (ToppingsField.Find(pT => pT == pTopping) == null)
        {
            ToppingsField.Add(pTopping);
        }
    }

    public void RemoveTopping(Topping pTopping)
    {
        ToppingsField.Remove(pTopping);
    }

    public decimal GetBasePrice()
    {
        return (decimal)Size / (decimal)PizzaSize.Default * Special.BasePrice;
    }

    public decimal GetTotalPrice() =>
        GetBasePrice() + ToppingsField.Sum(pT => pT.Price);

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public string GetFormattedSizeWithTotalPrice() =>
        $"{Size} cm ({GetFormattedTotalPrice()})";

    public bool HasMaximumToppings => Toppings.Count >= 6;

    public static explicit operator PlaceOrderPizzaDto(Pizza pIzza) =>
        new PlaceOrderPizzaDto
        {
            PizzaSpecialId = pIzza.Special.Id,
            Size = pIzza.Size,
            ToppingsIds = pIzza.Toppings.Select(pT => pT.Id).ToList()
        };
}
