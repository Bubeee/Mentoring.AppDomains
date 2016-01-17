using System;
using System.Reflection;
using System.Security.Policy;

namespace Mentoring.WorkingWithAppDomains
{
    public class PluginLoader : MarshalByRefObject
    {
        public AppDomain CurrentDomain { get; set; }

        public object LoadAssembly(string assemblyPath, string typeName)
        {
            var domainSetup = new AppDomainSetup
                                  {
                                      ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                                      ApplicationName = "CalculatorPlugin",
                                      DynamicBase = AppDomain.CurrentDomain.BaseDirectory
                                  };

            var domain = AppDomain.CreateDomain("PluginDomain", new Evidence(), domainSetup);
            var assembly = Assembly.LoadFile(assemblyPath);
            this.CurrentDomain = domain;
            return domain.CreateInstanceAndUnwrap(assembly.FullName, typeName);
        }

        public void UnloadAssembly()
        {
            AppDomain.Unload(this.CurrentDomain);
        }
    }
}