using API_BANK.Data;
using API_BANK.DTO;
using API_BANK.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//INYECTAR CONECCTION
var connectionString = builder.Configuration.GetConnectionString("PosgreSQLConecction");
builder.Services.AddDbContext<PruebaTecnicaContext>(options=>
options.UseNpgsql(connectionString));

//FIN
//CABEZERA PARA ADMITIR RELACION DE BACKEND Y FRONTEND
builder.Services.AddCors(option =>
{
    option.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//apis

app.MapPost("/empleados/", async (Empleado e, PruebaTecnicaContext db) =>
{
    db.Empleados.Add(e);
    await db.SaveChangesAsync();
    return Results.Created($"/empleados/{e.Id}", e);
});
app.MapGet("/empleados/{id:int}", async (int id, PruebaTecnicaContext db) =>
{
    return await db.Empleados.FindAsync(id)
    is Empleado e
    ? Results.Ok(e)
    : Results.NotFound();
});
app.MapGet("/departamentos/{id:int}", async (int id, PruebaTecnicaContext db) =>
{
    return await db.Departamentos.FindAsync(id)
    is Departamento e
    ? Results.Ok(e)
    : Results.NotFound();
});
app.MapGet("/empleados",async(PruebaTecnicaContext db)=>await db.Empleados.ToListAsync());
app.MapGet("/departamentos", async (PruebaTecnicaContext db) => await db.Departamentos.ToListAsync());
app.MapDelete("/empleados/{id:int}", async(int id,PruebaTecnicaContext db)=>
{
    var emple = await db.Empleados.FindAsync(id);
    if (emple is null) return Results.NotFound();

    db.Empleados.Remove(emple);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapPut("/empleados/{id:int}",async(int id,Empleado e,PruebaTecnicaContext db) =>
{
    if (e.Id != id)
        return Results.BadRequest();
    var emple = await db.Empleados.FindAsync(id);
    if(emple is null)
    {
        return Results.NotFound();
    }
    emple.Nombre= e.Nombre;
    emple.Apellido = e.Apellido;
    emple.Area = e.Area;
    emple.Correo = e.Correo;
    emple.Telefono = e.Telefono;
    await db.SaveChangesAsync();
    return Results.Ok(emple);

});
//

app.UseCors("NuevaPolitica");
app.Run();




internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
