namespace BlazingPizza.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsPresenter
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync(
        IReadOnlyCollection<PizzaSpecial> pSpecials);
}
