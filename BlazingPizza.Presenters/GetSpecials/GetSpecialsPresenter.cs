namespace BlazingPizza.Presenters.GetSpecials;
internal sealed class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;

    public GetSpecialsPresenter(IOptions<SpecialsOptions> options)
    {
        ImagesBaseUrl = options.Value.ImagesBaseUrl;
    }

    public Task<IReadOnlyCollection<PizzaSpecial>>
        GetSpecialsAsync(IReadOnlyCollection<PizzaSpecial> specials)
    {
        foreach (PizzaSpecial? special in specials)
        {
            special.ImageUrl = $"{ImagesBaseUrl}/{special.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
}
