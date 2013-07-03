namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_a_fooid_inline
    {
        [Test]
        public void Should_provide_a_clear_syntax_for_method_selection()
        {
            FooId<TestFeature> fooId = FooIds.Enabled<TestFeature>();

            fooId.If(() =>
                {
                    // run if it is enabled
                });

            fooId.Unless(() =>
                {
                    // run if disabled
                });

            fooId.If(() =>
                {
                    /* enabled */
                }, () =>
                    {
                        /* disabled */
                    });


            var result = fooId.Iff(() => 27, () => 42);
            Assert.AreEqual(27, result);

            var value = fooId.Iff((a, b) => a, (a, b) => b, 27, 42);
            Assert.AreEqual(27, value);
        }


        class TestFeature :
            FooId
        {
        }
    }
}