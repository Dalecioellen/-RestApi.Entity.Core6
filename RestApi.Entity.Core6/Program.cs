
using RestApi.Entity.Core6.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using RestApi.Entity.Core6.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Tudo que eu for injetar será aqui
builder.Services.AddControllers();
builder.Services.AddDbContext<Db_Context>(x => x.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnections")

  ));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

//Objetos transitórios são sempre diferentes; uma nova instância é fornecida para cada controlador e cada serviço.

//Objetos com escopo são os mesmos em uma solicitação, mas diferentes em solicitações diferentes.

//Os objetos singleton são os mesmos para todos os objetos e todas as solicitações.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
