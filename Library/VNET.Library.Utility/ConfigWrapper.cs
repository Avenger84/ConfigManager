using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.ConfigManager;
using VNET.Library.ConfigManager.Interfaces;

namespace VNET.Library.Utility
{
    public static class ConfigWrapper
    {
        private static IConfigManager _confManager = new RegConfigManager("sahibindenTest");
        public static IConfigs Config = new Configs(_confManager);
    }
}
