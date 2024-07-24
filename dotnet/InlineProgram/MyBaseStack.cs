using Pulumi;
using System.Collections.Generic;
using System;

namespace InlineProgram;
public class MyBaseStack : Stack
{

    public MyBaseStack() : base(new StackOptions
    {
        ResourceTransformations = {
                args =>
                {
                    var tagPpty = args.Args.GetType().GetProperty("Tags");
                    if (tagPpty != null)
                    {
                        string resourceName = args.Resource.GetResourceName();
                        string resourceType = args.Resource.GetResourceType();

                        object tagsValue = tagPpty.GetValue(args.Args, null);
                        if (tagsValue is not InputMap<string>)
                        {
                            Pulumi.Log.Debug($"Tags property is not of type InputMap<string> for resource {resourceType} named {resourceName}");
                            return null;
                        }

                        try
                        {
                            InputMap<string> inputs = new InputMap<string> { {"taggg","teerere"} };
                            tagPpty.SetValue(args.Args, inputs, null);
                            return new ResourceTransformationResult(args.Args, (CustomResourceOptions)args.Options);
                        }
                        catch (Exception e)
                        {
                            Pulumi.Log.Warn($"Error setting tags for resource {resourceType} named {resourceName}: {e.Message}");
                            return null;
                        }
                    }
                    return null;
                }
        }

    })
    { }
}