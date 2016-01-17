using System;

using SomeTestAssembly;

namespace Mentoring.WorkingWithAppDomains
{
    public class Program
    {
        static void Main(string[] args)
        {
            var domainLoader = new PluginLoader();
            var pluginPath =
                @"d:\Mentoring\MyTasks\Mentoring.WorkingWithAppDomains\SomeTestAssembly\bin\Debug\SomeTestAssembly.dll";
            var typeName = "SomeTestAssembly.Calculator";

            var reference = (Calculator)domainLoader.LoadAssembly(pluginPath, typeName);
            
            Console.WriteLine(reference.Add(2, 30));
            Console.ReadLine();
            domainLoader.UnloadAssembly();
            Console.WriteLine(reference.Add(2, 30));
            Console.WriteLine("Don't got here");
            Console.ReadLine();
        }
    }
}
