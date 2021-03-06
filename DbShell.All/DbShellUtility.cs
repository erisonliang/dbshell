﻿using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.All
{
    public static class DbShellUtility
    {
        private static bool _registeredEncodings = false;

        public static IServiceProvider BuildDefaultServiceProvider()
        {
            if (!_registeredEncodings)
            {
                _registeredEncodings = true;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            }

            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddConsole());
            services.AddDbShell();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static void Run(this IRunnable runnable)
        {
            var serviceProvider = BuildDefaultServiceProvider();
            runnable.Run(serviceProvider);
        }
    }
}
