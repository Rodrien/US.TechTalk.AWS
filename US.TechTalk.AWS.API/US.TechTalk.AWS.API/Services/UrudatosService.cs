using US.TechTalk.AWS.API.Domain;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Services
{
    public class UrudatosService : IUrudatosService
    {
        public Task CreateAsync(Urudato urudato)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Urudato>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Urudato> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
