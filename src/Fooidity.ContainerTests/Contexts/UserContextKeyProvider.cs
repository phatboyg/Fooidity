namespace Fooidity.ContainerTests.Contexts
{
    public class UserContextKeyProvider :
        IContextKeyProvider<UserContext>
    {
        public string GetKey(UserContext context)
        {
            return context.Name;
        }
    }
}