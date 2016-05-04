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
    public class DBConfigManager : ConfigManager, IConfigManager
    {
        private IDBConfigDao _dbConfigDao;
        private string _configName;

        public DBConfigManager(IDBConfigDao dbConfigDao, string configName)
        {
            _dbConfigDao = dbConfigDao;
            _configName = configName;

            Task task = Task.Factory.StartNew(() => base.StartConfigCache());

            task.Wait();
        }

        public string GetKeyValue(string key)
        {
            return base.GetValue(key);
        }

        public string this[string key]
        {
            get
            {
                return base.GetValue(key);
            }
        }

        public override void FillConfigValues()
        {
            ConfigCollection configCollection = _dbConfigDao.GetConfigVaribales(_configName);

            base.SetConfigValuesToCache(configCollection);
        }
    }
}
