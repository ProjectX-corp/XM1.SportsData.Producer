using System.Text.Json.Serialization;
using XM1.SportsData.Producer.API.Configuration;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration, builder.Environment);

var app = builder.Build();
app.Run();


