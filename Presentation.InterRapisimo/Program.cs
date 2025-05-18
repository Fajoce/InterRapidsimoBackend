using Application.InteRapidisimo.Services;
using Application.InteRapidisimo.Services.Alumnos.Matriculas;
using Application.InteRapidisimo.Services.Asignaciones;
using Application.InteRapidisimo.Services.Calificaciones;
using Application.InteRapidisimo.Services.Docentes;
using Application.InteRapidisimo.Services.Grados;
using Application.InteRapidisimo.Services.Materias;
using Application.InteRapidisimo.Services.Usuarios;
using Domain.IterRapisimo.ExceptionMiddleware;
using Domain.IterRapisimo.Interfaces;
using Domain.IterRapisimo.Repositories;
using Domain.IterRapisimo.Repositories.Asignaciones;
using Domain.IterRapisimo.Repositories.Calificaciones;
using Domain.IterRapisimo.Repositories.Docentes;
using Domain.IterRapisimo.Repositories.Grados;
using Domain.IterRapisimo.Repositories.Materias;
using Domain.IterRapisimo.Repositories.matriculas;
using InfraStrucure.InterRapidisimo.IOD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.MyDependencies(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddScoped<IUsuarioRepository, ServiceImpl>();
builder.Services.AddScoped<IAlumnosRepository, AlumnosServiceImpl>();
builder.Services.AddScoped<IGradosRepository, GradosServiceImpl>();
builder.Services.AddScoped<IMatriculasRepository, MatriculaServiceIml>();
builder.Services.AddScoped<IDocentesRepository, DocentesServiceImpl>();
builder.Services.AddScoped<IMateriasRepository, MateriasServiceImpl>();
builder.Services.AddScoped<IAsignacionesRepository, AsignacionesServiceImpl>();
builder.Services.AddScoped<ICalificacionesRepository, CalificacionesServiceImpl>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("myPolicies");
app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.Run();
