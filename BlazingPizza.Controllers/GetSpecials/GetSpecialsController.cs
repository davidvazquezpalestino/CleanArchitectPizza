namespace BlazingPizza.Controllers.GetSpecials;
public class GetSpecialsController : IGetSpecialsController
{
    readonly IGetSpecialsInputPort InputPort;
    readonly IGetSpecialsPresenter Presenter;

    public GetSpecialsController(IGetSpecialsInputPort pInputPort,
        IGetSpecialsPresenter pResenter)
    {
        InputPort = pInputPort;
        Presenter = pResenter;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Presenter.GetSpecialsAsync(
            await InputPort.GetSpecialsAsync());
    }
}
