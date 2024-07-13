using US.TechTalk.AWS.API.Domain;
using US.TechTalk.AWS.API.Mapping;
using US.TechTalk.AWS.API.Repositories;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Services
{
    public class UrudatosService(IUrudatosRepository urudatosRepository) : IUrudatosService
    {
        private readonly IUrudatosRepository _urudatosRepository = urudatosRepository;

        public async Task<bool> CreateAsync(Urudato urudato)
        {
            var response = await _urudatosRepository.CreateAsync(urudato.ToUrudatoDto());

            return response;
        }

        public async Task<Urudato?> GetAsync(Guid id)
        {
            var response = await _urudatosRepository.GetAsync(id);

            if (response is null)
            {
                return null;
            }

            Urudato urudato = response.ToUrudato();

            return urudato;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
            // Here goes access to DB

            // More custom logic
            //Urudato urudato = Urudato.Dummy();

            //var response = true;

            //if (response)
            //{
            //    await _snsMessenger.PublishMessageAsync(urudato.ToUrudatoDeletedMessage());
            //}

            //return response;
        }

        public Task<IEnumerable<Urudato>> GetAllAsync()
        {
            throw new NotImplementedException();
        }        
    }
}
