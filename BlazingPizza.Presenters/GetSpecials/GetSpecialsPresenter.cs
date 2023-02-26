﻿namespace BlazingPizza.Presenters.GetSpecials;
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
        foreach (var Special in specials)
        {
            Special.ImageUrl = $"{ImagesBaseUrl}/{Special.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
}
