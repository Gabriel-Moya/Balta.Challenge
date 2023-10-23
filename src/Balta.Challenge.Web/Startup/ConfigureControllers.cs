using Balta.Challenge.Web.Controllers;

namespace Balta.Challenge.Web.Startup;

public static class ConfigureControllers
{
    public static void AddControllers(this WebApplication app)
    {
        HelloWorldController.HelloWorldDemo(app);
        AccountController.MapAccountEndpoints(app);
        LocaleController.MapLocaleEndpoints(app);
        // Add news controllers here
    }
}
