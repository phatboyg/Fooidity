namespace Fooidity.Tests
{
    namespace ToggleSwitch_Specs
    {
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
                IToggleCodeSwitch<A> toggle = CodeSwitch.Factory.Toggle<A>();

                toggle.Enable();

                Assert.IsTrue(toggle.Enabled);
            }

            [Test]
            public void Should_change_state_to_disabled()
            {
                IToggleCodeSwitch<A> toggle = CodeSwitch.Factory.Toggle<A>(true);


                toggle.Disable();

                Assert.IsFalse(toggle.Enabled);
            }
        }
    }
}