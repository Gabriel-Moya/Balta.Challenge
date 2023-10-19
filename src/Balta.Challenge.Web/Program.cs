using Balta.Challenge.Web.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerConfiguration();

app.AddControllers();

app.Run();
