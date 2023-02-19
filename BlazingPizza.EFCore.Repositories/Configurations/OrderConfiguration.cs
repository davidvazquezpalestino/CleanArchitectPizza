namespace BlazingPizza.EFCore.Repositories.Configurations;
internal class OrderConfiguration :
    IEntityTypeConfiguration<EFEntities.Order>
{
    public void Configure(EntityTypeBuilder<EFEntities.Order> pBuilder)
    {
        pBuilder.OwnsOne(pO => pO.DeliveryLocation);
    }
}
