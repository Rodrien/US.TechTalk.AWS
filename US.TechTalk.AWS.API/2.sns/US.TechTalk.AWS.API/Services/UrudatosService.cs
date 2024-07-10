using US.TechTalk.AWS.API.Domain;
using US.TechTalk.AWS.API.Mapping;
using US.TechTalk.AWS.API.Messaging;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Services
{
    public class UrudatosService(ISnsMessenger snsMessenger) : IUrudatosService
    {
        private readonly ISnsMessenger _snsMessenger = snsMessenger;

        public async Task<bool> CreateAsync(Urudato urudato)
        {
            // Here goes access to DB

            // More custom logic

            var response = true;

            if (response)
            {
                await _snsMessenger.PublishMessageAsync(urudato.ToUrudatoCreatedMessage());
            }

            return response;
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
