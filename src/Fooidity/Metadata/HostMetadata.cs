namespace Fooidity.Metadata
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using Contracts;


    /// <summary>
    /// Caches the host data so it isn't queried multiple times
    /// </summary>
    public class HostMetadata :
        IHostMetadata
    {
        readonly Host _host;

        HostMetadata()
        {
            _host = CreateHost();
        }

        public static Host Host
        {
            get { return Cached.Instance.Value.Host; }
        }

        Host IHostMetadata.Host
        {
            get { return _host; }
        }

        static Host CreateHost()
        {
            var host = new Host
            {
                MachineName = Environment.MachineName,
                FooidityVersion = typeof(ICodeSwitch<>).Assembly.GetName().Version.ToString(),
                FrameworkVersion = Environment.Version.ToString(),
                OsVersion = Environment.OSVersion.ToString()
            };

            Process currentProcess = Process.GetCurrentProcess();
            host.ProcessId = currentProcess.Id;
            host.ProcessName = currentProcess.ProcessName;

            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyName assemblyName = entryAssembly.GetName();
                host.Assembly = assemblyName.Name;
                host.AssemblyVersion = assemblyName.Version.ToString();
            }

            return host;
        }


        static class Cached
        {
            internal static readonly Lazy<IHostMetadata> Instance = new Lazy
                <IHostMetadata>(() => new HostMetadata(), LazyThreadSafetyMode.PublicationOnly);
        }
    }
}