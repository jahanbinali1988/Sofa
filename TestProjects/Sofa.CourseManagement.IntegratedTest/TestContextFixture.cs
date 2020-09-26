using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;
using Serilog.Events;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.Web;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class TestContextFixture : IDisposable
    {
        IWebHostBuilder webHostbuilder;
        IConfiguration configuration;
        TestServer testServer;

        public TestContextFixture()
        {
            IdentityServerRunner.Run();
            configuration = GetConfiguration();
            webHostbuilder = GetWebHostBuilder(configuration);
            ConfigLogger(configuration);
            testServer = new TestServer(webHostbuilder);
            DatabaseInitializer.RebuildDatabase(configuration);
        }

        public HttpClient GetHttpClient()
        {
            return testServer.CreateClient();
        }

        public HttpClient GetAuthenticatedHttpClient(string userName, string password)
        {
            var testHttpClient = GetHttpClient();
            return LoginUtility.GetAuthenticatedHttpClient(userName, password, testHttpClient);
        }

        private IConfiguration GetConfiguration()
        {
            string currentDirectory = PlatformServices.Default.Application.ApplicationBasePath;
            string settingsPath = Path.Combine(currentDirectory, "testappsettings.json");

            var builder = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddJsonFile(settingsPath);

            return builder.Build();
        }

        private void ConfigLogger(IConfiguration configuration)
        {
            var path = configuration.GetValue<string>("logFilePath");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.File(
                     path: path,
                     fileSizeLimitBytes: 1_000_000,
                     rollOnFileSizeLimit: true,
                     shared: true,
                     flushToDiskInterval: TimeSpan.FromSeconds(1))
                .CreateLogger();
        }

        private IWebHostBuilder GetWebHostBuilder(IConfiguration configuration)
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(GetContentRoot())
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .UseSerilog()
                .UseConfiguration(configuration);

            return builder;
        }

        private string GetContentRoot()
        {
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = integrationTestsPath.Replace("TestProjects\\Sofa.CourseManagement.IntegratedTest", "Sofa.Web");

            return applicationPath;
        }

        public void Dispose()
        {
            IdentityServerRunner.Stop();
        }
    }



    [CollectionDefinition("TestContext collection")]
    public class TestContextCollection : ICollectionFixture<TestContextFixture>
    {
    }
}
