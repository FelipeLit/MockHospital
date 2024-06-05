using Microsoft.EntityFrameworkCore;
using practica1.Data;
using practica1.Services.CItas;
using practica1.Services.Emails;
using practica1.Services.Especialidades;
using practica1.Services.Medicos;
using practica1.Services.Pacientes;
using practica1.Services.Tratamientos;

var builder = WebApplication.CreateBuilder(args);

//Controladoes

builder.Services.AddControllers();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//conexion a Bd
builder.Services.AddDbContext<HospitalContext>(
    opt => opt.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2")));

//Añadir interfaces al contenedor de dependecias
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ICitaRepository,CitaRepository>();
builder.Services.AddScoped<ITratamientoRepository,TratamientoRepository>();
builder.Services.AddScoped<IMailService, MailService>();

//peticones HTTP
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
