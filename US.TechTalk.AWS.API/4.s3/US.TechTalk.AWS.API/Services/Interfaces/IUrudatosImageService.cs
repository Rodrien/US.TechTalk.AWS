using Amazon.S3.Model;

namespace US.TechTalk.AWS.API.Services.Interfaces
{
    public interface IUrudatosImageService
    {
        Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file);

        Task<GetObjectResponse> GetImageAsync(Guid id);

        Task<DeleteObjectResponse> DeleteImageAsync(Guid id);
    }
}
