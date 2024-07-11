using US.TechTalk.AWS.API.Contracts;
using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Mapping;

public static class DomainToApiContractMapper
{
    public static UrudatoResponse ToUrudatoResponse(this Urudato urudato)
    {
        return new UrudatoResponse
        {
            Id = urudato.Id,
            Name = urudato.Name,
            Email = urudato.Email,
            DateOfBirth = urudato.DateOfBirth
        };
    }
}
