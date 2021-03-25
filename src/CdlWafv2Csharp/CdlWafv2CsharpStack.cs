using Amazon.CDK;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;
using Amazon.CDK.AWS.WAFv2;

using System.Collections.Generic;

//using DefaultActionProperty = Amazon.CDK.AWS.WAFv2.DefaultActionProperty;
//using OverrideActionProperty = Amazon.CDK.AWS.WAFv2.OverrideActionProperty;


namespace CdlWafv2Csharp
{
    public class CdlWafv2CsharpStack : Stack
    {
        internal CdlWafv2CsharpStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
             // The CDK includes built-in constructs for most resource types, such as Queues and Topics.
           var _ = new CfnWebACL(this, "WebAcl", new CfnWebACLProps
            {
  
                /*
                DefaultAction = new CfnWebACL.DefaultActionProperty
                {
                    Allow = {}
                },
                */
                
                DefaultAction = new CfnWebACL.DefaultActionProperty
                {
                    Allow = new Dictionary<string, object>()
                },
                
                VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                {
                    CloudWatchMetricsEnabled = true,
                    SampledRequestsEnabled = true,
                    MetricName = "test-waf-metric",
                },
                Scope = "REGIONAL",
                Rules = new object[]
                {
                    new CfnWebACL.RuleProperty
                    {
                        Name = "AWS-AWSManagedRulesCommonRuleSet",
                        Priority = 0,
                        Statement = new CfnWebACL.StatementOneProperty
                        {
                            ManagedRuleGroupStatement = new CfnWebACL.ManagedRuleGroupStatementProperty
                            {
                                VendorName = "AWS",
                                Name = "AWSManagedRulesCommonRuleSet",
                            },
                        },
                        VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                        {
                                CloudWatchMetricsEnabled = true,
                                SampledRequestsEnabled = true,
                                MetricName = "AWS-AWSManagedRulesCommonRuleSet",
                        },
                        OverrideAction = new CfnWebACL.OverrideActionProperty
                        {
                            Count = new Dictionary<string, object>()
                        },
                    },
                }
            });
        }
    }
}
