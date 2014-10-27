namespace Fooidity.Tests
{
    namespace CodeFeatureName
    {
        using Metadata;
        using NUnit.Framework;
        using Shouldly;


        public struct SampleCodeFeature :
            CodeFeature
        {
        }


        [TestFixture]
        public class A_code_feature_name
        {
            [Test]
            public void Should_form_a_proper_urn()
            {
                CodeFeatureMetadata<SampleCodeFeature>.Id.ShouldBe(
                    "urn:feature:SampleCodeFeature:Fooidity.Tests.CodeFeatureName");
            }
        }
    }
}