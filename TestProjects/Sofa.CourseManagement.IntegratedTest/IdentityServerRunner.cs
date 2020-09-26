using Microsoft.Extensions.PlatformAbstractions;
using System.Diagnostics;

namespace Sofa.CourseManagement.IntegratedTest
{
    public static class IdentityServerRunner
    {
        private static bool serverRunned;
        private static InnerRunner innerRunner;

        static IdentityServerRunner()
        {
            serverRunned = false;
        }

        public static void Run()
        {
            if (serverRunned)
                return;

            serverRunned = true;
            innerRunner = new InnerRunner();
            innerRunner.Run();
        }

        public static void Stop()
        {
            innerRunner.Kill();
        }

        class InnerRunner
        {
            Process process;

            public void Run()
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "dotnet";
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.WorkingDirectory = GetServerPath();
                psi.Arguments = ".\\Sofa.Identity.WebAPI.dll";
                process = Process.Start(psi);
            }

            public void Kill()
            {
                try
                {
                    process.Kill();
                }
                catch { }
            }

            private string GetServerPath()
            {
                var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationPath = integrationTestsPath.Replace("TestProjects\\Sofa.CourseManagement.IntegratedTest", "Identity\\Sofa.Identity.WebAPI");

                return applicationPath;
            }
        }
    }
}
