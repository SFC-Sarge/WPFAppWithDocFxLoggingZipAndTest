using Microsoft.VisualStudio.TestTools.UnitTesting;
using $specifiedsolutionname$;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Properties;
using $safeprojectname$;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace $safeprojectname$.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        public TestContext? TestContext { get; set; }

        public static string? CurrentAppPath { get; set; }
        public static string? CurrentUnitTestLogDirValue { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            CurrentAppPath = FileLoggerProvider.AppPath();
            CurrentUnitTestLogDirValue = Path.Combine(CurrentAppPath, Resources.CurrentUnitTestLogDirValue);
            if (!Directory.Exists(CurrentUnitTestLogDirValue))
                Directory.CreateDirectory(CurrentUnitTestLogDirValue);
            TestProperties.UnitTestLogger.LogInformation($"{context.FullyQualifiedTestClassName} Started Class Testing: ******************************************************************************************", true);
            TestProperties.UnitTestLogger.LogInformation($"{Environment.NewLine}******************************************************************************************{Environment.NewLine}", true);
        }
        [TestInitialize]
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public void TestInitialize() => TestProperties.UnitTestLogger.LogInformation($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}Start Test: ******************************************************************************************", true);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        [TestCleanup()]
        public void Cleanup()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            {
                TestProperties.UnitTestLogger.LogInformation($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}Expected and Actual Are Equal! Test Result: {TestContext.CurrentTestOutcome}.", true);
            }
            else
            {
                TestProperties.UnitTestLogger.LogWarning($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}Test Result: {TestContext.CurrentTestOutcome}.", true);
            }
            TestProperties.UnitTestLogger.LogInformation($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}End Test: ******************************************************************************************{Environment.NewLine}", true);
            TestProperties.UnitTestLogger.LogInformation($"******************************************************************************************{Environment.NewLine}", true);
        }

        [TestMethod()]
        public void AppPathTest()
        {
            try
            {
                // Arrange
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerProvider.AppPath(): Expected Value:{Environment.NewLine}'{true}'", true);
                // Act
                string ActualAppPathValue = FileLoggerProvider.AppPath();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerProvider.AppPath(): Actual Value is not Null:{Environment.NewLine}'{ActualAppPathValue.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Assert
                Assert.IsNotNull(ActualAppPathValue);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerProvider.AppPath() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerProvider.AppPath(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerProvider.AppPath() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void AppNameTest()
        {
            try
            {
                // Arrange
                string ExpectedAppNameValue = Resources.ExpectedAppNameValue;
                TestProperties.UnitTestLogger.LogInformation($"MainWindow.AppName(): Expected Value:{Environment.NewLine}'{ExpectedAppNameValue.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualAppNameMainWindowValue = MainWindow.AppName();
                TestProperties.UnitTestLogger.LogInformation($"MainWindow.AppName(): Actual Value:{Environment.NewLine}'{ActualAppNameMainWindowValue.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Assert
                Assert.AreEqual(ExpectedAppNameValue, ActualAppNameMainWindowValue);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"MainWindow.AppName() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}MainWindow.AppName(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End MainWindow.AppName() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }
    }
}