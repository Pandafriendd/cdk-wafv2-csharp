using Amazon.CDK;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;

namespace CdlWafv2Csharp
{
    public class CdlWafv2CsharpStack : Stack
    {
        internal CdlWafv2CsharpStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
             // The CDK includes built-in constructs for most resource types, such as Queues and Topics.
            var queue = new Queue(this, "CdlWafv2CsharpQueue", new QueueProps
            {
                VisibilityTimeout = Duration.Seconds(300)
            });

            var topic = new Topic(this, "CdlWafv2CsharpTopic");

            topic.AddSubscription(new SqsSubscription(queue));
        }
    }
}
