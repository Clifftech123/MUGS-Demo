var builder = DistributedApplication.CreateBuilder(args);



var apiService = builder.AddProject<Projects.MUGS2024dEMO_ApiService>("apiservice");


builder.AddProject<Projects.MUGS2024dEMO_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)

    .WaitFor(apiService);




builder.Build().Run();
