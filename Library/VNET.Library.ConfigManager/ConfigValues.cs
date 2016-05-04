using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.ConfigManager
{
    internal sealed class ConfigValues
    {
        private static readonly Lazy<ConfigValues> lazy = new Lazy<ConfigValues>(() => new ConfigValues());

        public static ConfigValues Instance { get { return lazy.Value; } }

        private static ConfigCollection _configCollection = new ConfigCollection();

        private ConfigValues()
        {

        }

        public void FillConfigValues(ConfigCollection configCollection)
        {
            _configCollection = configCollection;
        }

        public void ClearConfigValues(List<KeyValuePair<string, string>> configData)
        {
            _configCollection.Clear();
        }

        public string GetValue(string key)
        {
            return _configCollection[key];
        }
    }
}
