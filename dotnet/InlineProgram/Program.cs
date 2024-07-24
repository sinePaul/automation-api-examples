using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.Automation;
using Pulumi.AzureNative;
using Pulumi.PulumiService;
using Pulumi.AzureNative.Maintenance;
using Pulumi.AzureNative.Maintenance.Inputs;
using Pulumi.AzureNative.Resources;

namespace InlineProgram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // define our pulumi program "inline"
            var program = PulumiFn.Create<MyStack>();



            var projectName = "EnvAccessTests";
            var stackName = "sinequacloud/plopa";

            var stackArgs = new InlineProgramArgs(projectName, stackName, program);
            var stack = await LocalWorkspace.CreateOrSelectStackAsync(stackArgs);

            Console.WriteLine("successfully initialized stack");

            // for inline programs, we must manage plugins ourselves
            Console.WriteLine("installing plugins...");
            await stack.Workspace.InstallPluginAsync("azure-native", typeof(Pulumi.AzureNative.Provider).Assembly.GetName().Version!.GetSemver());
            Console.WriteLine("plugins installed");

            // set stack configuration specifying the region to deploy
            Console.WriteLine("setting up config...");
            await stack.SetConfigAsync("azure-native:location", new ConfigValue("eastus"));
            await stack.SetConfigAsync("azure-native:subscriptionId", new ConfigValue("c6b97ef5-feda-4672-8f30-593c1f06604d"));
            //await stack.SetConfigAsync("environment", new ConfigValue($"[\"QA\"]"));
            //await stack.AddEnvironmentsAsync(new List<string>() { "QA" });

            //stack.Confi

            await stack.SetTagAsync("euwyeuwye", "weiwueiuweiu");


            //stack.Workspace.

            //stack.

            Console.WriteLine("config set");

            //Console.WriteLine("refreshing stack...");
            //await stack.RefreshAsync(new RefreshOptions { OnStandardOutput = Console.WriteLine });
            //Console.WriteLine("refresh complete");

            //await stack.DestroyAsync();
            Console.WriteLine("updating stack...");
            var result = await stack.UpAsync(new UpOptions { OnStandardOutput = Console.WriteLine });


            //stack.State.


            //Console.WriteLine("destroying stack...");
            //await stack.DestroyAsync(new DestroyOptions { OnStandardOutput = Console.WriteLine });
            //Console.WriteLine("stack destroy complete");
            //else
            //{

            //    if (result.Summary.ResourceChanges != null)
            //    {
            //        Console.WriteLine("update summary:");
            //        foreach (var change in result.Summary.ResourceChanges)
            //            Console.WriteLine($"    {change.Key}: {change.Value}");
            //    }

            //    Console.WriteLine($"website url: {result.Outputs["website_url"].Value}");
            //}
        }
    }

    public static class VersionExtensions
    {
        public static string GetSemver(this Version version)
        {
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }
    }

}
