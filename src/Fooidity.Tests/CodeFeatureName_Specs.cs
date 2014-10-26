namespace Fooidity.Tests
{
    namespace CodeFeatureName
    {
        using NUnit.Framework;


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
                Assert.AreEqual("urn:feature:SampleCodeFeature:Fooidity.Tests.CodeFeatureName",
                    CodeFeatureCache<SampleCodeFeature>.Id);
            }
        }
    }
}