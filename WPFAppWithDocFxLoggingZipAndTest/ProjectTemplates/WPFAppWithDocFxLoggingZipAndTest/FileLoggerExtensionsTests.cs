using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using $specifiedsolutionname$;
using $safeprojectname$;
using $safeprojectname$.Properties;

namespace $safeprojectname$.Tests
{
    [TestClass()]
    public class FileLoggerExtensionsTests
    {
        public TestContext? TestContext { get; set; }
        public static ILoggerFactory? ActualFactory { get; set; }
        public static ILogger? Logger { get; set; }
        public static ServiceProvider? serviceProvider { get; set; }
        public static ILogger<TestController>? logger { get; set; }
        public static TestController? logMessage { get; set; }
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
        public void TestInitialize()
        {
            serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .BuildServiceProvider();
#pragma warning disable CS8604 // Possible null reference argument.
            logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<TestController>();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            TestProperties.UnitTestLogger.LogInformation($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}Start Test: ******************************************************************************************", true);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            serviceProvider.GetService<ILoggerFactory>().Dispose();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            TestProperties.UnitTestLogger.LogInformation($"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}(){Environment.NewLine}End Test: ******************************************************************************************{Environment.NewLine}", true);
            TestProperties.UnitTestLogger.LogInformation($"******************************************************************************************{Environment.NewLine}", true);
        }

        [TestMethod()]
        public void AddFileTest()
        {
            try
            {
                // Arrange
                string ExpectedFactory = Resources.ExpectedFactoryValue;
                TestProperties.UnitTestLogger.LogInformation($"LoggerFactory().AddFile(): Expected Value:{Environment.NewLine}'{ExpectedFactory.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                ActualFactory = new LoggerFactory().AddFile(Resources.UnitTestLogFileNameTest, Resources.CurrentUnitTestLogDirValue);
                TestProperties.UnitTestLogger.LogInformation($"LoggerFactory().AddFile(): Actual Value:{Environment.NewLine}'{ActualFactory}'", true);
                // Assert
                Assert.AreEqual(ExpectedFactory, $"{ActualFactory}");
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"LoggerFactory().AddFile() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}LoggerFactory().AddFile(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End LoggerFactory().AddFile() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
            finally
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                ActualFactory.Dispose();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        [TestMethod()]
        public void LogTest()
        {
            try
            {
                // Arrange
                string ExpectedLogMessage = Resources.UnitTestLogMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.Log(): Expected Value:{Environment.NewLine}'{ExpectedLogMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.Log(): Actual Value:{Environment.NewLine}'{ActualLogMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogMessage, ActualLogMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.Log() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.Log(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.Log() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogTest1()
        {
            try
            {
                // Arrange
                string ExpectedLogMessage = Resources.UnitTestLogMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.Log(): Expected Value:{Environment.NewLine}'{ExpectedLogMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.Log(): Actual Value:{Environment.NewLine}'{ActualLogMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogMessage, ActualLogMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.Log() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.Log(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.Log() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogErrorTest()
        {
            try
            {
                // Arrange
                string ExpectedLogErrorMessage = Resources.UnitTestLogErrorMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogErrorMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogError(): Expected Value:{Environment.NewLine}'{ExpectedLogErrorMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogErrorMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogError(): Actual Value:{Environment.NewLine}'{ActualLogErrorMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogErrorMessage, ActualLogErrorMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.LogError() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.LogError(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.LogError() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogInformationTest()
        {
            try
            {
                // Arrange
                string ExpectedLogInformationMessage = Resources.UnitTestLogInformationMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogInformationMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogInformation(): Expected Value:{Environment.NewLine}'{ExpectedLogInformationMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogInformationMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogInformation(): Actual Value:{Environment.NewLine}'{ActualLogInformationMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogInformationMessage, ActualLogInformationMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.LogInformation() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.LogInformation(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.LogInformation() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogTraceTest()
        {
            try
            {
                // Arrange
                string ExpectedLogTraceMessage = Resources.UnitTestLogTraceMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogTraceMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogTrace(): Expected Value:{Environment.NewLine}'{ExpectedLogTraceMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogTraceMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogTrace(): Actual Value:{Environment.NewLine}'{ActualLogTraceMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogTraceMessage, ActualLogTraceMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.LogTrace() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.LogTrace(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.LogTrace() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogDebugTest()
        {
            try
            {
                // Arrange
                string ExpectedLogDebugMessage = Resources.UnitTestLogDebugMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogDebugMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogDebug(): Expected Value:{Environment.NewLine}'{ExpectedLogDebugMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogDebugMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogDebug(): Actual Value:{Environment.NewLine}'{ActualLogDebugMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogDebugMessage, ActualLogDebugMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.LogDebug() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.LogDebug(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.LogDebug() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void LogWarningTest()
        {
            try
            {
                // Arrange
                string ExpectedLogWarningMessage = Resources.UnitTestLogWarningMessage;
#pragma warning disable CS8604 // Possible null reference argument.
                logMessage = new TestController(logger, ExpectedLogWarningMessage);
#pragma warning restore CS8604 // Possible null reference argument.
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogWarning(): Expected Value:{Environment.NewLine}'{ExpectedLogWarningMessage.ToString(System.Globalization.CultureInfo.GetCultureInfo(Resources.cultures))}'", true);
                // Act
                string ActualLogWarningMessage = logMessage.GetMessage();
                TestProperties.UnitTestLogger.LogInformation($"FileLoggerExtensions.LogWarning(): Actual Value:{Environment.NewLine}'{ActualLogWarningMessage}'", true);
                // Assert
                Assert.AreEqual(ExpectedLogWarningMessage, ActualLogWarningMessage);
            }
            catch (AssertFailedException ex)
            {
                TestProperties.UnitTestLogger.LogError(ex, $"FileLoggerExtensions.LogWarning() Exception:{Environment.NewLine}{ex.Message}{Environment.NewLine}FileLoggerExtensions.LogWarning(): Failed", true, true);
                TestProperties.UnitTestLogger.LogInformation($"End FileLoggerExtensions.LogWarning() Test: ******************************************************************************************{Environment.NewLine}{Environment.NewLine}", true);
                Assert.Fail(ex.Message);
            }
        }
    }
}