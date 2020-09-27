using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.Loader;
using System.Reflection;

namespace Landr.SDK
{
    public class ExternalAppProvider : IAppProvider
    {
        private static object _lockObject = new object();
        private const string DllSearchPattern = "*.dll";

        private List<IApp> apps;
        private string[] assemblies;

        public bool IsLoading { get; private set; } = false;

        public ExternalAppProvider()
        {
            Initialize(new string[] { Environment.CurrentDirectory });
        }

        public ExternalAppProvider(params string[] assemblies)
        {
            Initialize(assemblies);
        }

        private void Initialize(string[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new string[] { Environment.CurrentDirectory };
            }

            var directories = assemblies.Where(a => Directory.Exists(a)).ToArray();
            var names = new List<string>(assemblies.Where(a => File.Exists(a) && a.ToLower().EndsWith(DllSearchPattern)).ToArray());


            foreach (var directory in directories)
            {
                var dlls = Directory.GetFiles(directory, DllSearchPattern);
                names.AddRange(dlls);
            }

            if (names.Count > 0)
            {
                this.assemblies = names.ToArray();
            }
            else
            {
                this.assemblies = new string[0];
            }

            apps = new List<IApp>(0);
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
                return new IApp[0];
            }

            var apps = new List<IApp>(appTypes.Length);

            foreach (var appType in appTypes)
            {
                var app = Activator.CreateInstance(appType, BindingFlags.Public | BindingFlags.Instance, null, environment, CultureInfo.CurrentCulture) as IApp;

                apps.Add(app);
            }

            return apps.ToArray();
        }

        private bool CheckFile(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(filename);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Load(params object[] environment)
        {
            lock (_lockObject)
            {
                if (IsLoading)
                {
                    return;
                }

                IsLoading = true;

                try
                {
                    apps = new List<IApp>();

                    foreach (var assemblyFile in assemblies)
                    {
                        var loadedApps = LoadAppsFromFile(assemblyFile, environment);

                        if (loadedApps.Length > 0)
                        {
                            apps.AddRange(loadedApps);
                        }
                    }
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        public IReadOnlyList<IApp> GetApps()
        {
            AssertHasFinishedLoading();

            return apps.ToArray();
        }

        public IReadOnlyList<TAppType> GetAppsOfType<TAppType>() where TAppType : IApp
        {
            AssertHasFinishedLoading();

            return apps.Where(a => a is TAppType).Select(a => (TAppType)a).ToArray();
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
