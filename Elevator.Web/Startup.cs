using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Elevator.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSignalRConnection"].ToString();
            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            app.MapSignalR();
        }
    }
}