using Steeltoe.Extensions.Configuration.ConfigServer;
using Venta.Api;
using Venta.Api.Configurations;
using Venta.Api.Middleware;
using Venta.Application;
using Venta.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddConfigServer(
    LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    })
    );


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CAPA DE APLICACIÓN
builder.Services.AddApplication();

//Capa de infraestructura
//var connectionString = builder.Configuration.GetConnectionString("dbVenta-cnx");
var connectionString = builder.Configuration["dbPago-cnx"];
//builder.Services.AddInfraestructure(connectionString);
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddAthenticationByJWT(); //autorizcion
builder.Services.AddHealthCheckConfiguration(builder.Configuration); //health

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();//thentication
app.UseAuthorization();
app.UseHealthCheckConfiguration();//helthy

//Adicionar middleware customizado para tratar las excepciones
app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
