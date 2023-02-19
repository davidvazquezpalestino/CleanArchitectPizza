namespace BlazingPizza.Presenters.GetSpecials;
public class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;

    public GetSpecialsPresenter(string pImagesBaseUrl)
    {
        ImagesBaseUrl = pImagesBaseUrl;
    }

    public Task<IReadOnlyCollection<PizzaSpecial>>
        GetSpecialsAsync(IReadOnlyCollection<PizzaSpecial> pSpecials)
    {
        foreach (var special in pSpecials)
        {
            special.ImageUrl = $"{ImagesBaseUrl}/{special.ImageUrl}";
        }
        return Task.FromResult(pSpecials);
    }
}
