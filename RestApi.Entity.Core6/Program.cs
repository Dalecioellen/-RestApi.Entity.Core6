
using RestApi.Entity.Core6.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using RestApi.Entity.Core6.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Tudo que eu for injetar ser� aqui
builder.Services.AddControllers();
builder.Services.AddDbContext<Db_Context>(x => x.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnections")

  ));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

//Objetos transit�rios s�o sempre diferentes; uma nova inst�ncia � fornecida para cada controlador e cada servi�o.

//Objetos com escopo s�o os mesmos em uma solicita��o, mas diferentes em solicita��es diferentes.

//Os objetos singleton s�o os mesmos para todos os objetos e todas as solicita��es.


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
