﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intern_Management.Startup))]
namespace Intern_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
