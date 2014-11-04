namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class A_dependent_fooid
    {
        [Test]
        public void Should_be_disabled_by_default()
        {
            IToggleCodeSwitch<Level1> level1 = CodeSwitch.Factory.Toggle<Level1>();

            ICodeSwitch<Level2> level2 = CodeSwitch.Factory.Dependent<Level2>(x => x.Upon(level1));

            Assert.IsFalse(level2.Enabled);
        }

        [Test]
        public void Should_be_enabled_to_be_enabled()
        {
            IToggleCodeSwitch<Level1> level1 = CodeSwitch.Factory.Toggle<Level1>();

            ICodeSwitch<Level2> level2 = CodeSwitch.Factory.Dependent<Level2>(x => x.Upon(level1));

            level1.Enable();
            Assert.IsTrue(level2.Enabled);
        }


        struct Level1 :
            ICodeFeature
        {
        }


        struct Level2 :
            ICodeFeature
        {
        }
    }
}