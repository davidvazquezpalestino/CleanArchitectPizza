namespace BlazingPizza.EFCore.Repositories.Configurations;
internal class PizzaToppingConfiguration :
    IEntityTypeConfiguration<PizzaTopping>
{
    public void Configure(EntityTypeBuilder<PizzaTopping> pBuilder)
    {
        pBuilder.HasKey(pT => new { pT.PizzaId, pT.ToppingId });
        pBuilder.HasOne<EFEntities.Pizza>().WithMany(p => p.Toppings);
        pBuilder.HasOne(pT => pT.Topping)
            .WithMany();
    }
}
