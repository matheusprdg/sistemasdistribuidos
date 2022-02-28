using ServidorWorker;
using SistemasDistribuidos.Application;
using SistemasDistribuidos.Application.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<ICalculadoraProvider, CalculadoraProvider>();
builder.Services.AddSingleton<IServidorEspecializadoProvider, ServidorEspecializadoProvider>();
builder.Services.AddSingleton<IServidorService, ServidorWorkerService>();
builder.Services.AddSingleton<IServidorEspecializadoRequestFactory, ServidorEspecializadoRequestFactory>();
builder.Services.AddSingleton<IResponseGetter, ResponseGetter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllMethods");
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
