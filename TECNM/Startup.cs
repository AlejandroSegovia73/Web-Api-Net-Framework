using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Builder;
using System.Web.Security;


//[assembly: OwinStartup(typeof(MembershipDetail.Startup))]

namespace TECNM
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigurarOauth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        public void ConfigurarOauth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
                Provider = new AutorizacionToken()

            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            OAuthAuthorizationServerOptions opciones = new OAuthAuthorizationServerOptions() { AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active };
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}