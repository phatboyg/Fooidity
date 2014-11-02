namespace Fooidity.Management.Web.Switching.Contexts
{
    public class UserContextKeyProvider :
        ContextKeyProvider<UserContext>
    {
        public string GetKey(UserContext context)
        {
            return context.Username;
        }
    }
}