using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appEnviroment = PlatformServices.Default.Application;
            Console.WriteLine($"Application: {appEnviroment.ApplicationName} v{appEnviroment.ApplicationVersion}");
            Console.WriteLine($"Framework: {appEnviroment.RuntimeFramework.Identifier} v{appEnviroment.RuntimeFramework.Version}");
            Console.WriteLine($"Runtime: {RuntimeInformation.FrameworkDescription} ({RuntimeInformation.ProcessArchitecture})");
            Console.WriteLine($"OS: {RuntimeInformation.OSDescription}({RuntimeInformation.OSArchitecture})");
            Console.WriteLine();

            var objectVersion = typeof(object).GetTypeInfo().Assembly.GetCustomAttributes().OfType<AssemblyInformationalVersionAttribute>().Single().InformationalVersion;
            var runtimeinfoVersion = typeof(RuntimeInformation).GetTypeInfo().Assembly.GetCustomAttributes().OfType<AssemblyFileVersionAttribute>().Single().Version;

            Console.WriteLine($"object v{objectVersion}");
            Console.WriteLine($"RuntimeInformation v{runtimeinfoVersion}");
            Console.ReadKey();

            /*
            Application: ConsoleApp1 v1.0.0.0
            Framework:   .NETCoreApp v1.0
            Runtime:     .NET Core 4.0.0.0 (X64)
            OS:          Microsoft Windows 10.0.10586 (X64)

            object              v4.6.24214.01
            RuntimeInformation  v1.0.24212.01
            */
        }
    }
}
