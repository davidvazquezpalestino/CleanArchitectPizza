namespace BlazingPizza.EFCore.Repositories.Configurations;
public class ToppingConfiguration :
    IEntityTypeConfiguration<Repositories.Entities.Topping>
{
    public void Configure(EntityTypeBuilder<Topping> pBuilder)
    {
        pBuilder.HasData(
            new Topping
            {
                Id = 1,
                Name = "Queso extra",
                Price = 47.50m
            },
            new Topping
            {
                Id = 2,
                Name = "Tocino de pavo",
                Price = 56.80m
            },
            new Topping
            {
                Id = 3,
                Name = "Tocino de jabalí",
                Price = 56.80m
            },
            new Topping
            {
                Id = 4,
                Name = "Tocino de ternera",
                Price = 56.80m
            },
            new Topping
            {
                Id = 5,
                Name = "Té y bollos",
                Price = 95.00m
            },
            new Topping
            {
                Id = 6,
                Name = "Bollos recién horneados",
                Price = 85.50m
            },
            new Topping
            {
                Id = 7,
                Name = "Pimiento",
                Price = 19.00m
            },
            new Topping
            {
                Id = 8,
                Name = "Cebolla",
                Price = 19.00m
            },
            new Topping
            {
                Id = 9,
                Name = "Champiñones",
                Price = 19.00m
            },
            new Topping
            {
                Id = 10,
                Name = "Pepperoni",
                Price = 19.00m
            },
            new Topping
            {
                Id = 11,
                Name = "Salchicha de pato",
                Price = 60.80m
            },
            new Topping
            {
                Id = 12,
                Name = "Albóndigas de venado",
                Price = 47.50m
            },
            new Topping
            {
                Id = 13,
                Name = "Cubierta de langosta",
                Price = 1225.50m
            },
            new Topping
            {
                Id = 14,
                Name = "Caviar de esturión",
                Price = 1933.25m
            },
            new Topping
            {
                Id = 15,
                Name = "Corazones de alcachofa",
                Price = 64.60m
            },
            new Topping
            {
                Id = 16,
                Name = "Tomates frescos",
                Price = 39.00m
            },
            new Topping
            {
                Id = 17,
                Name = "Albahaca",
                Price = 39.00m
            },
            new Topping
            {
                Id = 18,
                Name = "Filete",
                Price = 161.50m
            },
            new Topping
            {
                Id = 19,
                Name = "Pimientos picantes",
                Price = 79.80m
            },
            new Topping
            {
                Id = 20,
                Name = "Pollo búfalo",
                Price = 95.00m
            },
            new Topping
            {
                Id = 21,
                Name = "Queso azul",
                Price = 47.50m
            }

            );
    }
}
