﻿using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

var getObjectRequest = new GetObjectRequest
{
    BucketName = "usawstechtalk",
    Key = "archivos/archivo.txt"
};

var response = await s3Client.GetObjectAsync(getObjectRequest);

using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());


Console.WriteLine(text);
