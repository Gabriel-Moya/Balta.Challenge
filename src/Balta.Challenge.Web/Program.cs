using Balta.Challenge.Web.Startup;
using Balta.Challenge.IoC;
using Balta.Challenge.Web.Extensions;
using Balta.Challenge.Core.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurations();
builder.AddMediator();
builder.AddJwtAuthentication();

builder.Services.AddSwaggerConfiguration();
builder.Services.DependencyInjectorApi(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerConfiguration();
app.AddControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
