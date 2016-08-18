using System;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(H2H_WebAdmin.Models.Startup))]
namespace H2H_WebAdmin.Models
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here    
            app.MapSignalR();
        }
    }
}