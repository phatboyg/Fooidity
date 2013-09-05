namespace Fooidity
{
    using System;


    public static class FooIds
    {
        /// <summary>
        /// Returns a FooId that is always enabled
        /// </summary>
        /// <typeparam name="T">The FooId type</typeparam>
        /// <returns></returns>
        public static FooId<T> Enabled<T>()
            where T : struct, FooId
        {
            return Cache<T>.EnabledFooId;
        }

        /// <summary>
        /// Returns a FooId that is always disabled
        /// </summary>
        /// <typeparam name="T">The FooId type</typeparam>
        /// <returns></returns>
        public static FooId<T> Disabled<T>()
            where T : struct, FooId
        {
            return Cache<T>.DisabledFooId;
        }

        /// <summary>
        /// Creates a FooId that can be toggled from enabled to disabled (and back, of course)
        /// </summary>
        /// <typeparam name="T">The FooId atom</typeparam>
        /// <param name="initial">The initial state of the FooId</param>
        /// <returns></returns>
        public static ToggleFooId<T> Toggle<T>(bool initial = false)
            where T : struct, FooId
        {
            return new ToggleFooId<T>(initial);
        }

        public static FooId<T> Dependent<T>(Func<DependentFooIdFactory<T>, FooId<T>> factoryMethod)
            where T : struct, FooId
        {
            return factoryMethod(Cache<T>.Factory);
        }


        static class Cache<T>
            where T : struct, FooId
        {
            internal static readonly FooId<T> DisabledFooId = new DisabledFooId<T>();
            internal static readonly FooId<T> EnabledFooId = new EnabledFooId<T>();
            internal static readonly DependentFooIdFactory<T> Factory = new DependentFooIdFactoryImpl<T>();
        }
    }
}