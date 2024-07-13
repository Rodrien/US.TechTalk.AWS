using US.TechTalk.AWS.API.Contracts.Data;
using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Mapping
{
    public static class DomainToDtoMapper
    {
        public static UrudatoDto ToUrudatoDto(this Urudato urudato)
        {
            return new UrudatoDto
            {
                Id = urudato.Id,
                Email = urudato.Email,
                Name = urudato.Name,
                DateOfBirth = urudato.DateOfBirth,
            };
        }
    }
}
