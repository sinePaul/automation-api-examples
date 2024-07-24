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
    public class MyStack : MyBaseStack
    {
        public MyStack()
        {

            var rg = new ResourceGroup("plop-plop-rg", new()
            {
                Location = "eastus",
            });

        }
    }
}