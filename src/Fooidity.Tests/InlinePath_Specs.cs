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


        struct TestFeature :
            FooId
        {
        }

        interface When<T>
            where T : struct, FooId
        {
            FooId<T> FooId { get; }
        }

        struct Floo<T, T1> :
            FooId<T>,
            When<T1>
            where T : struct, FooId
            where T1 : struct, FooId
        {
            readonly FooId<T1> _fooId;
            readonly bool _enabled;

            public Floo(FooId<T1> fooId, bool enabled)
                : this()
            {
                _fooId = fooId;
                _enabled = enabled;
            }

            FooId<T1> When<T1>.FooId
            {
                get { return _fooId; }
            }

            public bool Enabled 
            {
                get { return _fooId.Enabled && _enabled; }
            }
        }
    }
}