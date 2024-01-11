using CarroponteAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/status", () => {
    var status = CarroponteInterface.GetStatus();

    return new { data = status.ToString() };
}).WithName("GetPlcStatus");

app.MapPost("/sale", () => CarroponteInterface.ToggleSale())
    .WithName("PostPlcSale");

app.MapPost("/scende", () => CarroponteInterface.ToggleScende())
    .WithName("PostPlcScende");

app.MapPost("/avanti", () => CarroponteInterface.ToggleAvanti())
    .WithName("PostPlcAvanti");

app.MapPost("/indietro", () => CarroponteInterface.ToggleIndietro())
    .WithName("PostPlcIndietro");

app.MapPost("/destra", () => CarroponteInterface.ToggleDestra())
    .WithName("PostPlcDestra");

app.MapPost("/sinistra", () => CarroponteInterface.ToggleSinistra())
    .WithName("PostPlcSinistra");

app.Run();