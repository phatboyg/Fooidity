namespace Fooidity.Contracts
{
    /// <summary>
    /// The host where the activity, compensation, or exception occurred while processing
    /// a routing slip
    /// </summary>
    public interface IHost
    {
        /// <summary>
        /// The machine name (or role instance name) of the local machine
        /// </summary>
        string MachineName { get; }

        /// <summary>
        /// The process name hosting the routing slip activity
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// The processId of the hosting process
        /// </summary>
        int ProcessId { get; }

        /// <summary>
        /// The assembly containing the activity
        /// </summary>
        string Assembly { get; }

        /// <summary>
        /// The assembly version of the assembly containing the activity
        /// </summary>
        string AssemblyVersion { get; }

        /// <summary>
        /// The .NET framework version
        /// </summary>
        string FrameworkVersion { get; }

        /// <summary>
        /// The version of MassTransit used by the process
        /// </summary>
        string FooidityVersion { get; }

        /// <summary>
        /// The operating system version hosting the application
        /// </summary>
        string OsVersion { get; }
    }
}