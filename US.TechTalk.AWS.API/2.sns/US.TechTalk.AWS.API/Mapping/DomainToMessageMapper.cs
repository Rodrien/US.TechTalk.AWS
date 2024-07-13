using US.TechTalk.AWS.API.Contracts;
using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Mapping;

public static class DomainToMessageMapper
{
    public static UrudatoCreated ToUrudatoCreatedMessage(this Urudato customer)
    {
        return new UrudatoCreated
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }

    public static UrudatoDeleted ToUrudatoDeletedMessage(this Urudato customer)
    {
        return new UrudatoDeleted
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            DateOfBirth = customer.DateOfBirth
        };
    }
}
