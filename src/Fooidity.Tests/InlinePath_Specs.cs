namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class Using_a_code_switch_inline
    {
        [Test]
        public void Should_provide_a_clear_syntax_for_method_selection()
        {
            CodeSwitch<TestFeature> codeSwitch = CodeSwitch.Enabled<TestFeature>();

            bool called = false;
            codeSwitch.If(() => { called = true; });
            Assert.IsTrue(called);

            codeSwitch.Unless(() => { Assert.Fail("Should not be called"); });

            called = false;
            codeSwitch.If(() => { called = true; }, () => { Assert.Fail("Should not be called"); });

            int result = codeSwitch.Iff(() => 27, () => 42);
            Assert.AreEqual(27, result);

            int value = codeSwitch.Iff((a, b) => a, (a, b) => b, 27, 42);
            Assert.AreEqual(27, value);
        }


        struct TestFeature :
            CodeFeature
        {
        }
    }
}