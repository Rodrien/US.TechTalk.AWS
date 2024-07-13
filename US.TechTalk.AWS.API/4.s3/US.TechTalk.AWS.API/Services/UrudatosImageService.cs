using Amazon.S3;
using Amazon.S3.Model;
using US.TechTalk.AWS.API.Services.Interfaces;

namespace US.TechTalk.AWS.API.Services
{
    public class UrudatosImageService(IAmazonS3 s3) : IUrudatosImageService
    {
        private readonly IAmazonS3 _s3 = s3;
        private readonly string _bucketName = "usawstechtalk";

        public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file)
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = $"fotos/{id}",
                ContentType = file.ContentType,
                InputStream = file.OpenReadStream(),
                Metadata =
                {
                    ["x-amz-meta-originalname"] = file.FileName,
                    ["x-amz-meta-extension"] = Path.GetExtension(file.FileName),
                },
                
            };

            return await _s3.PutObjectAsync(putObjectRequest);
        }

        public async Task<GetObjectResponse> GetImageAsync(Guid id)
        {
            var getObjectRequest = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = $"fotos/{id}"
            };

            return await _s3.GetObjectAsync(getObjectRequest);
        }

        public async Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = $"fotos/{id}"
            };

            return await _s3.DeleteObjectAsync(deleteObjectRequest);
        }
    }
}
