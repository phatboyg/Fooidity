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
            codeSwitch.If(() =>
            {
                called = true;
            });
            Assert.IsTrue(called);

            codeSwitch.Unless(() =>
            {
                Assert.Fail("Should not be called");
            });

            called = false;
            codeSwitch.If(() =>
            {
                called = true;
            }, () =>
            {
                Assert.Fail("Should not be called");
            });

            var result = codeSwitch.Iff(() => 27, () => 42);
            Assert.AreEqual(27, result);

            var value = codeSwitch.Iff((a, b) => a, (a, b) => b, 27, 42);
            Assert.AreEqual(27, value);
        }


        struct TestFeature :
            CodeFeature
        {
        }

        interface When<T>
            where T : struct, CodeFeature
        {
            CodeSwitch<T> ICodeSwitch { get; }
        }

        struct Floo<T, T1> :
            CodeSwitch<T>,
            When<T1>
            where T : struct, CodeFeature
            where T1 : struct, CodeFeature
        {
            readonly CodeSwitch<T1> _codeSwitch;
            readonly bool _enabled;

            public Floo(CodeSwitch<T1> codeSwitch, bool enabled)
                : this()
            {
                _codeSwitch = codeSwitch;
                _enabled = enabled;
            }

            CodeSwitch<T1> When<T1>.ICodeSwitch
            {
                get { return _codeSwitch; }
            }

            public bool Enabled 
            {
                get { return _codeSwitch.Enabled && _enabled; }
            }
        }
    }
}