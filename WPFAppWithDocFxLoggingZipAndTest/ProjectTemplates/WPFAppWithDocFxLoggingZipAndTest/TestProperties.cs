using Microsoft.Extensions.Logging;
using System;

using $safeprojectname$.Properties;

namespace $safeprojectname$
{
    public partial class TestProperties
    {
        public static WpftestPropertiesValues WpftestPropertiesValues = new();

        public static ILoggerFactory UnitTestFactory { get; set; } = new LoggerFactory()
            .AddFile(Resources.UnitTestLogFileName, Resources.CurrentUnitTestLogDirValue);
        public static ILogger UnitTestLogger { get; set; } = UnitTestFactory.CreateLogger(Resources.UnitTestLogFileName);

        public TestProperties()
        {
        }

    }
}
