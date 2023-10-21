using Balta.Challenge.Web.Startup;
using Balta.Challenge.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();

builder.Services.DependencyInjectorApi(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerConfiguration();

app.AddControllers();

app.Run();
