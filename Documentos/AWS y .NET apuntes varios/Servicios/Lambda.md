Instalar templates lambda
``` 
dotnet new install Amazon.Lambda.Templates
```


Instalar cli
```
dotnet tool install -g Amazon.Lambda.Tools
```

doc .net lambda cli tool: https://docs.aws.amazon.com/lambda/latest/dg/csharp-package-cli.html


# Publish lambda
``` bash
dotnet lambda deploy-function ImageS3Lambda
dotnet lambda deploy-function ResizeFotosS3Lambda
```

