namespace SpecificationValidation.Abstractions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidatorsFromAssembly(
        this IServiceCollection services, Assembly assembly)
    {
        services.RegisterServices(assembly, typeof(Specification<>),
            typeof(ISpecification<>))
            .RegisterServices(assembly, typeof(Validator<>),
            typeof(IValidator<>));

        return services;
    }

    private static IServiceCollection RegisterServices(
        this IServiceCollection services,
        Assembly assembly, Type genericBaseType, Type genericInterfaceType)
    {
        var servicesAndImplementations = assembly.GetTypes()
            .Where(t => t.BaseType != null &&
                t.BaseType.IsGenericType &&
                t.BaseType.GetGenericTypeDefinition() == genericBaseType)
            .Select(t => new
            {
                Service = t.BaseType
                            .GetInterfaces()
                            .FirstOrDefault(i => i.IsGenericType &&
                                   i.GetGenericTypeDefinition()
                                    == genericInterfaceType),
                Implementation = t
            })
            .ToList();

        servicesAndImplementations.ForEach(s =>
            services.AddScoped(s.Service, s.Implementation));

        return services;
    }
}
