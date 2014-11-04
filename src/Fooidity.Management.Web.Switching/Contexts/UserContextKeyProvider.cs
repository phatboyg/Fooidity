namespace Fooidity.Management.Web.Switching.Contexts
{
    public class UserContextKeyProvider :
        IContextKeyProvider<UserContext>
    {
        public string GetKey(UserContext context)
        {
            return context.Username;
        }
    }
}