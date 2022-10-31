using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace AppTemplateCore.Helpers
{
    public class VersionHelper
    {
        public string? AppName { get; private set; }
        public string? AppVersion { get; private set; }
        public string? AssemblyName { get; private set; }
        public string? AssemblyVersion { get; private set; }

        public VersionHelper()
        {
            var asm = Assembly.GetExecutingAssembly();
            var product = asm.GetCustomAttributes(typeof(AssemblyProductAttribute), true).FirstOrDefault() as AssemblyProductAttribute;
            
            AppName = product?.Product;
            AppVersion = asm.GetName()?.Version?.ToString();
            AssemblyName = typeof(Controller).Assembly.GetName().Name;
            AssemblyVersion = typeof(Controller).Assembly.GetName()?.Version?.ToString();
        }
    }
}