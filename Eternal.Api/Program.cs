using Eternal.Api;
using Eternal.Business;
using Eternal.Data;
using Eternal.DataAccess;
using Eternal.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AuthorizationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<EternalDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Contract>, Repository<Contract>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Dependent>, Repository<Dependent>>();
builder.Services.AddScoped<IRepository<Instalment>, Repository<Instalment>>();
builder.Services.AddScoped<IRepository<ContractTemplate>, Repository<ContractTemplate>>();
builder.Services.AddScoped<IInstalmentRepository, InstalmentRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDependentService, DependentService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IContractTemplateService, ContractTemplateService>();
builder.Services.AddScoped<IInstalmentService, InstalmentService>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EternalDbContext>();
    var database = dataContext.Database;
    database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
