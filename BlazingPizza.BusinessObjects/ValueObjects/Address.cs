namespace BlazingPizza.BusinessObjects.ValueObjects;
public record Address(
    string Name, string AddressLine1, string AddressLine2,
    string City, string Region, string PostalCode, string PhoneNumber
    );
