using US.TechTalk.AWS.API.Domain;

namespace US.TechTalk.AWS.API.Services.Interfaces
{
    public interface IUrudatosService
    {
        Task<bool> CreateAsync(Urudato urudato);

        Task<bool> DeleteAsync(Guid id);

        Task<Urudato> GetAsync(Guid id);

        Task<IEnumerable<Urudato>> GetAllAsync();
    }
}
