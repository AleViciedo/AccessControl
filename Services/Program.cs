using AccessControl.Services.Services;
using Services.Services;
using AccessControl.DataAccess;
using AccessControl.DataAccess.Context;
using AccessControl.Contracts;
using Contracts.Entities;
using AccessControl.DataAccess.Repositories.Entities;
using Contracts.ValueObjects;
using AccessControl.DataAccess.Repositories.ValueObjects;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton("Data Source=Data.sqlite");
builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAccessEntryRepository, AccessEntryRepository>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();

builder.Services.AddMediatR(new MediatRServiceConfiguration()
{
    AutoRegisterRequestProcessors = true,
}.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OperatorService>();
app.MapGrpcService<SupervisorService>();
app.MapGrpcService<ProcessService>();
app.MapGrpcService<AccessEntryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
