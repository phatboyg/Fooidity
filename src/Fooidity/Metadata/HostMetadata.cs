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
            _host = new HostImpl();
        }

        public static Host Host
        {
            get { return Cached.Instance.Value.Host; }
        }

        Host IHostMetadata.Host
        {
            get { return _host; }
        }


        static class Cached
        {
            internal static readonly Lazy<IHostMetadata> Instance = new Lazy
                <IHostMetadata>(() => new HostMetadata(), LazyThreadSafetyMode.PublicationOnly);
        }


        class HostImpl :
            Host
        {
            readonly string _assembly;
            readonly string _assemblyVersion;
            readonly string _fooidityVersion;
            readonly string _frameworkVersion;
            readonly string _machineName;
            readonly string _osVersion;
            readonly int _processId;
            readonly string _processName;

            public HostImpl()
            {
                _machineName = Environment.MachineName;
                _fooidityVersion = typeof(CodeSwitch<>).Assembly.GetName().Version.ToString();
                _frameworkVersion = Environment.Version.ToString();
                _osVersion = Environment.OSVersion.ToString();
                Process currentProcess = Process.GetCurrentProcess();
                _processId = currentProcess.Id;
                _processName = currentProcess.ProcessName;

                Assembly entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
                if (entryAssembly != null)
                {
                    AssemblyName assemblyName = entryAssembly.GetName();
                    _assembly = assemblyName.Name;
                    _assemblyVersion = assemblyName.Version.ToString();
                }
            }

            public string FooidityVersion
            {
                get { return _fooidityVersion; }
            }

            public string MachineName
            {
                get { return _machineName; }
            }

            public string ProcessName
            {
                get { return _processName; }
            }

            public int ProcessId
            {
                get { return _processId; }
            }

            public string Assembly
            {
                get { return _assembly; }
            }

            public string AssemblyVersion
            {
                get { return _assemblyVersion; }
            }

            public string FrameworkVersion
            {
                get { return _frameworkVersion; }
            }

            public string OsVersion
            {
                get { return _osVersion; }
            }
        }
    }
}