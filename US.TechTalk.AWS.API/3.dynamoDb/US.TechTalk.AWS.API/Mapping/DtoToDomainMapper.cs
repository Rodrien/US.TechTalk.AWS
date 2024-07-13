using US.TechTalk.AWS.API.Contracts.Data;
using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Mapping
{
    public static class DtoToDomainMapper
    {
        public static Urudato ToUrudato(this UrudatoDto urudatoDto)
        {
            return new Urudato
            {
                Id = urudatoDto.Id,
                Name = urudatoDto.Name,
                Email = urudatoDto.Email,
                DateOfBirth = urudatoDto.DateOfBirth
            };
        }
    }
}
