namespace Fooidity
{
    public static class FooIds
    {
        /// <summary>
        /// Returns a FooId that is always disabled
        /// </summary>
        /// <typeparam name="T">The FooId type</typeparam>
        /// <returns></returns>
        public static FooId<T> Disabled<T>()
            where T : FooId
        {
            return Cache<T>.DisabledFooId;
        }

        /// <summary>
        /// Returns a FooId that is always enabled
        /// </summary>
        /// <typeparam name="T">The FooId type</typeparam>
        /// <returns></returns>
        public static FooId<T> Enabled<T>()
            where T : FooId
        {
            return Cache<T>.EnabledFooId;
        }


        static class Cache<T>
            where T : FooId
        {
            internal static readonly FooId<T> DisabledFooId = new DisabledFooId<T>();
            internal static readonly FooId<T> EnabledFooId = new EnabledFooId<T>();
        }
    }
}