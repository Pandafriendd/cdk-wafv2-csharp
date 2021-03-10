using Amazon.CDK;

namespace CdlWafv2Csharp
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CdlWafv2CsharpStack(app, "CdlWafv2CsharpStack");

            app.Synth();
        }
    }
}
