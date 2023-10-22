namespace Balta.Challenge.Web.Controllers;

public static class HelloWorldController
{
    public static void HelloWorldDemo(this WebApplication app)
    {
        app.MapGet("/hello", () => "Hello World!");
    }
}
