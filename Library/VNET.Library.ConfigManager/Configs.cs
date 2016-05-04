using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNET.Library.ConfigManager
{
    public static class Configs
    {
        public static string DOMAIN_NAME { get { return ConfigValues.Instance.GetValue("DOMAIN_NAME"); } }
        public static string CONNECTION_STRING { get { return ConfigValues.Instance.GetValue("CONNECTION_STRING"); } }
        public static string AdminName { get { return ConfigValues.Instance.GetValue("AdminName"); } }
    }
}
