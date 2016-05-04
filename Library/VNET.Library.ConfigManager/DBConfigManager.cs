using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.DataLibrary.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.ConfigManager
{
    public class DBConfigManager : IConfigManager
    {
        private IDBConfigDao _dbConfigDao;
        private string _configName;

        private static ConfigCollection _configCollection;

        public DBConfigManager(IDBConfigDao dbConfigDao, string configName)
        {
            _dbConfigDao = dbConfigDao;
            _configName = configName;

            ConfigCacheManager cacheManager = new ConfigCacheManager(this);

            Task task = Task.Factory.StartNew(() => cacheManager.StartConfigCache());

            task.Wait();
        }

        public string GetKeyValue(string key)
        {
            if (_configCollection == null)
            {
                FillConfig();
            }

            return _configCollection[key];
        }


        public string this[string key]
        {
            get
            {
                if (_configCollection == null)
                {
                    FillConfig();
                }

                return _configCollection[key];
            }
            set { }
        }

        private void FillConfig()
        {
            _configCollection = _dbConfigDao.GetConfigVaribales(_configName);
        }


        public void FillConfigValues()
        {
            ConfigCollection configCollection = _dbConfigDao.GetConfigVaribales(_configName);

            ConfigValues.Instance.FillConfigValues(configCollection);
        }
    }
}
