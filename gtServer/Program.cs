using Microsoft.AspNetCore.Mvc;
using gtServer.Objects;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Allow the frontend to access this webAPI
builder.Services.AddCors();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(policy => policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod());

app.MapGet("/testScale", () =>
{
    var scale = new List<string>
    {
        "A", "B", "C", "D", "E", "F", "G"
    };
    return scale;
})
.WithName("GetTestScale");

app.MapGet("/scale", ([FromQuery] string key,
                      [FromQuery] string keyType,
                      [FromQuery] string tuning,
                      [FromQuery] string tuningType,
                      [FromQuery] string scaleType,
                      [FromQuery] int numStrings) =>
{
    // Simplified fretboard containing stringified notes from each string.
    Dictionary<string, object> result = new();
    List<List<string>> fretboard = [];
    GuitarTuner tuner = new(tuning, tuningType, numStrings);
    ScaleBuilder scaleBuilder = new();
    // Build the fretboard and calculate scale
    tuner.TuneGuitar();
    scaleBuilder.BuildScales(key, keyType, scaleType);
    // Simplify return values into list of strings
    foreach (GuitarString gString in tuner.Fretboard.GuitarStrings)
    {
        fretboard.Add(gString.SNotes);
    }
    result.Add("fretboard", fretboard);
    result.Add("scale", scaleBuilder.SScale);

    return Results.Ok(result);
})
.WithName("GetScale");

app.Run();