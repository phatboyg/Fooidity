namespace Fooidity.Tests
{
    namespace ToggleSwitch_Specs
    {
        using CodeSwitches;
        using NUnit.Framework;


        struct A :
            CodeFeature
        {
        }


        [TestFixture]
        public class Toggling_a_code_switch
        {
            [Test]
            public void Should_change_state()
            {
                ToggleCodeSwitch<A> toggle = CodeSwitch.Factory.Toggle<A>();

                Assert.IsFalse(toggle.Enabled);

                toggle.Enable();

                Assert.IsTrue(toggle.Enabled);

                toggle.Disable();

                Assert.IsFalse(toggle.Enabled);
            }
        }
    }
}