namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class A_dependent_fooid
    {
        [Test]
        public void Should_be_enabled_to_be_enabled()
        {
            var level1 = CodeSwitch.Toggle<Level1>();

            var level2 = CodeSwitch.Dependent<Level2>(x => x.Upon(level1));

            Assert.IsFalse(level2.Enabled);

            level1.Enable();
            Assert.IsTrue(level2.Enabled);
        }


        struct Level1 :
            CodeFeature
        {
        }

        struct Level2 :
            CodeFeature
        {
        }
    }
}
