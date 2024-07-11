using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();


using var inputStream = new FileStream("./logo.png", FileMode.Open, FileAccess.Read);

var putObjectRequest = new PutObjectRequest
{
    BucketName = "usawstechtalk",
    Key = "logos/logo.png",
    ContentType = "image/png",
    InputStream = inputStream,
};

await s3Client.PutObjectAsync(putObjectRequest);