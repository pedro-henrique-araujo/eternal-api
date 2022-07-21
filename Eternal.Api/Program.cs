using Eternal.Business;
using Eternal.Data;
using Eternal.DataAccess;
using Eternal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EternalDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Contract>, Repository<Contract>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Instalment>, Repository<Instalment>>();
builder.Services.AddScoped<IInstalmentRepository, InstalmentRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IInstalmentService, InstalmentService>();

var app = builder.Build();

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
