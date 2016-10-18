using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiniCore.Container.UnitTests.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
