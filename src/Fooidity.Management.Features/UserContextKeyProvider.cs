namespace Fooidity.Management.Features
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