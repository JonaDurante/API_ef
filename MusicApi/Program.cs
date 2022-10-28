using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -- agregado para poder utilizar entityframework
builder.Services.AddDbContext<ApiDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
// -- Fin agregado

var app = builder.Build();

// -- agregado para poder utilizar entityframework
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    //dbContext.Database.EnsureCreated();           //Nos permite crear la db si no está creada, pero si modificamos nuestra entidad, no modifica esta en la base
    dbContext.Database.Migrate();
}
// -- Fin agregado

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
