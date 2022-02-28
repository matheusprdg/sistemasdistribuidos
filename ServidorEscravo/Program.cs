using ServidorEscravo;
using SistemasDistribuidos.Application;
using SistemasDistribuidos.Application.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IServidorEscravoProvider, ServidorEscravoProvider>();
builder.Services.AddSingleton<IServidorService, ServidorEscravoService>();
builder.Services.AddSingleton<IServidorEscravoRequestFactory, ServidorWorkerRequestFactory>();
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
