﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Architecture.Web.Mapping;
using Architecture.Web.Capsule;

[assembly: OwinStartup(typeof(AJSwithAPI.Startup))]

namespace AJSwithAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var mappingDefinitions = new MappingDefinitions();
            mappingDefinitions.Initialise();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            WebApiConfig.Register(config);

            new WebCapsule().Initialise(config);

            app.UseWebApi(config);

        }
    }
}
