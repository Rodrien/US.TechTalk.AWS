using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Services.Interfaces
{
    public interface IUrudatosService
    {
        Task CreateAsync(Urudato urudato);

        Task<Urudato> GetAsync(Guid id);

        Task<IEnumerable<Urudato>> GetAllAsync();
    }
}
