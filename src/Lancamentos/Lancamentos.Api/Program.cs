using Lancamentos.Business.LancamentoBLL;
using Lancamentos.Business.LancamentoBLL.Interface;
using Lancamentos.Domain;
using Lancamentos.Infrastructure.Persistence.LancamentosDB;
using Lancamentos.Infrastructure.Persistence.LancamentosDB.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Lancamentos.Infrastructure.Persistence.LancamentosDB.Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("lancamentosDB")));

builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<IPostData, PostData>();

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