using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.ConfigManager
{
    public class RegConfigManager : IConfigManager
    {
        private string _registryName;
        private RegistryKey _baseKey = null;

        public RegConfigManager(string registeryName)
        {
            _registryName = registeryName;

            _baseKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\" + _registryName, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.ReadKey);

            ConfigCacheManager cacheManager = new ConfigCacheManager(this);

            Task task = Task.Factory.StartNew(() => cacheManager.StartConfigCache());

            task.Wait();
        }

        public string GetKeyValue(string key)
        {
            return _baseKey.GetValue(key, string.Empty).ToString();
        }

        ~RegConfigManager()
        {
            _baseKey.Close();
        }

        public string this[string key]
        {
            get
            {
                return GetKeyValue(key);
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void FillConfigValues()
        {
            string[] valueNames = _baseKey.GetValueNames();

            ConfigCollection configCollection = new ConfigCollection();

            foreach (string name in valueNames)
            {
                configCollection.Add(new KeyValuePair<string, string>(name, _baseKey.GetValue(name, string.Empty).ToString()));
            }

            ConfigValues.Instance.FillConfigValues(configCollection);
        }
    }
}
