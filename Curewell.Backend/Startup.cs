using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Threading.Tasks;
using Curewell.Backend.Provider;

[assembly: OwinStartup(typeof(Curewell.Backend.Startup))]

namespace Curewell.Backend
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);//Middleware
            var provider = new AuthProvider();
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                TokenEndpointPath = new PathString("/token"),
                Provider = provider
            };

            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());//Generate Token
        }
    }
}
