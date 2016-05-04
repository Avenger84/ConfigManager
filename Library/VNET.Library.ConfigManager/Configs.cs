using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.ConfigManager.Interfaces;

namespace VNET.Library.ConfigManager
{
    public class Configs : IConfigs
    {
        private IConfigManager _configManager;

        public Configs(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public string AdminId { get { return _configManager.GetKeyValue("AdminId"); } }
        public string AdminName { get { return _configManager.GetKeyValue("AdminName"); } }
        public string ConnectionString { get { return _configManager.GetKeyValue("ConnectionString"); } }
    }
}
