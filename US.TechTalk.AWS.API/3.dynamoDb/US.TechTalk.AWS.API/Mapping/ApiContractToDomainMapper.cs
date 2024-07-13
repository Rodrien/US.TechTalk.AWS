using US.TechTalk.AWS.API.Contracts;
using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Mapping;

public static class ApiContractToDomainMapper
{
    public static Urudato ToUrudato(this UrudatoRequest request)
    {
        return new Urudato
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
    }
}
