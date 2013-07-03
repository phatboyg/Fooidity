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
            return DisabledCache<T>.CachedValue;
        }

        /// <summary>
        /// Returns a FooId that is always enabled
        /// </summary>
        /// <typeparam name="T">The FooId type</typeparam>
        /// <returns></returns>
        public static FooId<T> Enabled<T>()
            where T : FooId
        {
            return EnabledCache<T>.CachedValue;
        }


        static class DisabledCache<T>
            where T : FooId
        {
            internal static readonly FooId<T> CachedValue = new DisabledFooId();


            class DisabledFooId :
                FooId<T>
            {
                bool FooId<T>.Enabled
                {
                    get { return false; }
                }
            }
        }


        static class EnabledCache<T>
            where T : FooId
        {
            internal static readonly FooId<T> CachedValue = new EnabledFooId();


            class EnabledFooId :
                FooId<T>
            {
                bool FooId<T>.Enabled
                {
                    get { return true; }
                }
            }
        }
    }
}