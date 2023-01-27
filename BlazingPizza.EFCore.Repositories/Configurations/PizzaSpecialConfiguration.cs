namespace BlazingPizza.EFCore.Repositories.Configurations;
class PizzaSpecialConfiguration :
    IEntityTypeConfiguration<Repositories.Entities.PizzaSpecial>
{
    public void Configure(EntityTypeBuilder<PizzaSpecial> pBuilder)
    {
        pBuilder.HasData(
            new PizzaSpecial
            {
                Id = 1,
                Name = "Pizza clásica de queso",
                Description = "Es de queso y delicioso. ¿Por qué no querrías una?",
                BasePrice = 189.99m,
                ImageUrl = "cheese.jpg"
            },
            new PizzaSpecial()
            {
                Id = 2,
                Name = "Tocinator",
                Description = "Tiene TODO tipo de tocino",
                BasePrice = 227.99m,
                ImageUrl = "bacon.jpg",
            },
            new PizzaSpecial()
            {
                Id = 3,
                Name = "Clásica de pepperoni",
                Description = "Es la pizza con la que creciste, ¡pero ardientemente deliciosa!",
                BasePrice = 199.50m,
                ImageUrl = "pepperoni.jpg",
            },
            new PizzaSpecial()
            {
                Id = 4,
                Name = "Pollo búfalo",
                Description = "Pollo picante, salsa picante y queso azul, garantizado que entrarás en calor",
                BasePrice = 228.75m,
                ImageUrl = "meaty.jpg",
            },
            new PizzaSpecial()
            {
                Id = 5,
                Name = "Amantes del champiñón",
                Description = "Tiene champiñones. ¿No es obvio?",
                BasePrice = 209.00m,
                ImageUrl = "mushroom.jpg",
            },
            new PizzaSpecial()
            {
                Id = 6,
                Name = "Hawaiana",
                Description = "De piña, jamón y queso...",
                BasePrice = 190.25m,
                ImageUrl = "hawaiian.jpg",
            },
            new PizzaSpecial()
            {
                Id = 7,
                Name = "Delicia vegetariana",
                Description = "Es como una ensalada, pero en una pizza",
                BasePrice = 218.50m,
                ImageUrl = "salad.jpg",
            },
            new PizzaSpecial()
            {
                Id = 8,
                Name = "Margarita",
                Description = "Pizza italiana tradicional con tomates y albahaca",
                BasePrice = 189.99m,
                ImageUrl = "margherita.jpg",
            }
            );
    }
}
