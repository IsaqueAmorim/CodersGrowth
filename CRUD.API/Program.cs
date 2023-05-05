

using CRUD.Infra.Repositorios;
using CRUD.Repositorios;
using CRUD.Servicos;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepositorioJogadores, Link2DBRepositorio>();
builder.Services.AddScoped<Validacao>();
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
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "text/plain;charset=utf-8",
    ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
 {
 {".properties", "text/plain;charset=utf-8" }
 })
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
