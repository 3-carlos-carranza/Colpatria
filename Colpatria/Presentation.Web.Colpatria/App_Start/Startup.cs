using Crosscutting.Mappers;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Presentation.Web.Colpatria
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = "ApplicationCookie",
                    LoginPath = new PathString("/Request/Index"),
                    CookieName = "colpatriaCkt"
                });
            AutomapperMaps.Initialize();
#if DEBUG
            TelemetryConfiguration.Active.DisableTelemetry = true;
#endif
        }
    }
}