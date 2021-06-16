using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.Loader;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Landr.SDK
{
    public class ExternalAppProvider : IAppProvider
    {
        private static readonly object LockObject = new object();
        private const string DllSearchPattern = "*.dll";

        private List<IApp> _apps = new(0);
        private string[] _assemblies = Array.Empty<string>();

        private readonly ILogger _logger;
        public bool IsLoading { get; private set; } = false;

        public ExternalAppProvider(ILogger<ExternalAppProvider> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private void Initialize(string[] assemblies)
        {
            _logger.LogDebug("Adding {Count} assemblies", assemblies.Length);
            
            if (assemblies.Length == 0)
            {
                _logger.LogDebug("Assembly list is empty, adding default directory {DefaultDirectory}", Environment.CurrentDirectory);
                assemblies = new[] { Environment.CurrentDirectory };
            }

            var directories = assemblies.Where(Directory.Exists).ToArray();
            var names = new List<string>(assemblies.Where(a => File.Exists(a) && a.ToLower().EndsWith(DllSearchPattern)).ToArray());

            _logger.LogDebug("Found {Count} directories with plugins", directories.Length);
            foreach (var directory in directories)
            {
                var dlls = Directory.GetFiles(directory, DllSearchPattern);
                names.AddRange(dlls);
            }
            
            _logger.LogDebug("Found {Count} plugin assemblies", names.Count);
            _assemblies = names.Count > 0 ? names.ToArray() : Array.Empty<string>();
        }

        private IApp[] LoadAppsFromFile(string filename, object[] environment)
        {
            if (CheckFile(filename) == false)
            {
                return new IApp[0];
            }

            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(filename);

            var appTypes = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IApp))).ToArray();

            if (appTypes.Length == 0)
            {
                return Array.Empty<IApp>();
            }

            var apps = new List<IApp>(appTypes.Length);

            foreach (var appType in appTypes)
            {
                if (Activator.CreateInstance(appType, BindingFlags.Public | BindingFlags.Instance, null, environment, CultureInfo.CurrentCulture) is IApp app)
                    apps.Add(app);
            }

            return apps.ToArray();
        }

        private bool CheckFile(string filename)
        {
            if (!File.Exists(filename)) return false;
            
            try
            {
                AssemblyLoadContext.Default.LoadFromAssemblyPath(filename);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The following exception occurred when checking loading the file {FileName}", filename);
                return false;
            }

            return false;
        }

        public Task LoadAsync(params object[] environment)
        {
            lock (LockObject)
            {
                if (IsLoading)
                {
                    return Task.CompletedTask;
                }

                IsLoading = true;

                try
                {
                    _apps = new List<IApp>(_assemblies.Length);

                    foreach (var assemblyFile in _assemblies)
                    {
                        var loadedApps = LoadAppsFromFile(assemblyFile, environment);

                        if (loadedApps.Length > 0)
                        {
                            _apps.AddRange(loadedApps);
                        }
                    }
                }
                finally
                {
                    IsLoading = false;
                }
            }
            
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<IApp>> GetAppsAsync()
        {
            AssertHasFinishedLoading();

            return Task.FromResult(_apps.ToArray() as IReadOnlyCollection<IApp>);
        }

        public Task<IReadOnlyCollection<TAppType>> GetAppsOfTypeAsync<TAppType>() where TAppType : IApp
        {
            AssertHasFinishedLoading();

            return Task.FromResult(_apps.OfType<TAppType>().ToArray() as IReadOnlyCollection<TAppType>);
        }

        private void AssertHasFinishedLoading()
        {
            if (IsLoading)
            {
                throw new InvalidOperationException($"We are not done loading yet. Please check {nameof(IsLoading)} before calling this method.");
            }
        }
    }
}
