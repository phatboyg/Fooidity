namespace Fooidity
{
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

        public static FooId<T> Enabled<T>(this T fooId)
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

        public static FooId<T> Disabled<T>(this T fooId)
            where T : struct, FooId
        {
            return Cache<T>.DisabledFooId;
        }

        public static SwitchableFooId<T> Initial<T>(this T fooId, bool initial)
            where T : struct, FooId
        {
            return new SwitchableFooId<T>(initial);
        }


        static class Cache<T>
            where T : struct, FooId
        {
            internal static readonly FooId<T> DisabledFooId = new DisabledFooId<T>();
            internal static readonly FooId<T> EnabledFooId = new EnabledFooId<T>();
        }
    }
}