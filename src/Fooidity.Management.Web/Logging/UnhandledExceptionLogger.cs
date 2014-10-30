namespace Fooidity.Management.Web.Logging
{
    using System.Web.Http.ExceptionHandling;


    public class UnhandledExceptionLogger :
        ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            base.Log(context);
        }
    }
}