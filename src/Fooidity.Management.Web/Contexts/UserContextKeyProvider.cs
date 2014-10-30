namespace Fooidity.Management.Web.Contexts
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