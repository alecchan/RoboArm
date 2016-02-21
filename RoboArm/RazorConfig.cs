using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboArm
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield break;
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield break;
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
