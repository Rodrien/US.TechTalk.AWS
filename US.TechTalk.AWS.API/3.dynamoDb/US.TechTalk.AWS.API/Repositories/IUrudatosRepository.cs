using US.TechTalk.AWS.API.Contracts.Data;

namespace US.TechTalk.AWS.API.Repositories
{
    public interface IUrudatosRepository
    {
        Task<bool> CreateAsync(UrudatoDto urudato);

        Task<UrudatoDto?> GetAsync(Guid id);
    }
}
