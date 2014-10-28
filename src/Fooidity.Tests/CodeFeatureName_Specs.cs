namespace Fooidity.Tests
{
    namespace CodeFeatureName
    {
        using System;
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
                    new Uri("urn:feature:SampleCodeFeature:Fooidity.Tests.CodeFeatureName:Fooidity.Tests"));
            }

            [Test]
            public void Should_not_include_assembly_name_if_the_same()
            {
                CodeFeatureMetadata<TopLevelCodeFeature>.Id.ShouldBe(
                    new Uri("urn:feature:TopLevelCodeFeature:Fooidity.Tests"));
            }
        }


        [TestFixture]
        public class A_code_feature_id
        {
            [Test]
            public void Should_be_parsed_into_a_type()
            {
                var id = new CodeFeatureId("urn:feature:SampleCodeFeature:Fooidity.Tests.CodeFeatureName:Fooidity.Tests");

                Type type = id.GetType();

                type.ShouldBe(typeof(SampleCodeFeature));
            }

            [Test]
            public void Should_be_parsed_into_a_type_without_the_namespace()
            {
                var id = new CodeFeatureId("urn:feature:TopLevelCodeFeature:Fooidity.Tests");

                Type type = id.GetType();

                type.ShouldBe(typeof(TopLevelCodeFeature));
            }
        }
    }


    public struct TopLevelCodeFeature :
        CodeFeature
    {
    }
}