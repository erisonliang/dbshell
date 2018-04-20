﻿using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.All
{
    public static class DbShellUtility
    {
        public static IServiceProvider BuildDefaultServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbShell();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static void Run(this IRunnable runnable)
        {
            var serviceProvider = BuildDefaultServiceProvider();
            runnable.Run(BuildDefaultServiceProvider());
        }
    }
}
