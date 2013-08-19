namespace Fooidity.Tests
{
    using NUnit.Framework;


    [TestFixture]
    public class A_dependent_fooid
    {
        [Test]
        public void Should_be_enabled_to_be_enabled()
        {
            var level1 = default(Level1).Initial(false);
            var level2 = default(Level2).Dependent(level1);

            Assert.IsFalse(level2.Enabled);

            level1.Enable();
            Assert.IsTrue(level2.Enabled);
        }


        struct Level1 :
            FooId
        {
        }

        struct Level2 :
            When<Level1>
        {
        }
    }
}
