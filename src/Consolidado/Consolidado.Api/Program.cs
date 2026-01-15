using Consolidado.Business.LancamentoBLL;
using Consolidado.Business.LancamentoBLL.Interface;
using Consolidado.Domain;
using Consolidado.Infrastructure.Persistence.ConsolidadoDB;
using Consolidado.Infrastructure.Persistence.ConsolidadoDB.Interface;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ?? Configuração Banco de Dados
builder.Services.AddDbContext<Consolidado.Infrastructure.Persistence.ConsolidadoDB.Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConsolidadoDB")));

builder.Services.AddScoped<IConsolidadoRepository, ConsolidadoRepository>();
builder.Services.AddScoped<IGetData, GetData>();


builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.Run();