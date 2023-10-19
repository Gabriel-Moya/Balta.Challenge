using Balta.Challenge.Web.Startup;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.AddControllers();

app.Run();
