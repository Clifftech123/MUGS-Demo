var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MUGS_Demo_ApiService>("apiservice");

builder.AddProject<Projects.MUGS_Demo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
