namespace Balta.Challenge.Web.Controllers;
public static class LocaleController
{
    public static void create(this WebApplication app)
    {
        app.MapGet("/create", () => "Create Locale");
    }
}
