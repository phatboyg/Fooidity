namespace Fooidity.Contracts
{
    public class Host :
        IHost
    {
        public string FooidityVersion { get; set; }

        public string MachineName { get; set; }

        public string ProcessName { get; set; }

        public int ProcessId { get; set; }

        public string Assembly { get; set; }

        public string AssemblyVersion { get; set; }

        public string FrameworkVersion { get; set; }

        public string OsVersion { get; set; }
    }
}