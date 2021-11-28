using Microsoft.Extensions.Logging;
using System;

using $safeprojectname$.Properties;

namespace $safeprojectname$
{
    public partial class TestProperties
    {
        public static WpftestPropertiesValues WpftestPropertiesValues = new();

#pragma warning disable CS8601 // Possible null reference assignment.
        public static ILoggerFactory UnitTestFactory { get; set; } = new LoggerFactory()
            .AddFile(Resources.UnitTestLogFileName, Resources.CurrentUnitTestLogDirValue);
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static ILogger UnitTestLogger { get; set; } = UnitTestFactory.CreateLogger(Resources.UnitTestLogFileName);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        public TestProperties()
        {
        }
    }
}
