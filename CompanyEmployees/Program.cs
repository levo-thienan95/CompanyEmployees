using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCros();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Infrastructure.Presentation.AssemblyReference).Assembly);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServicesManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Host.UseSerilog((hostContext, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();