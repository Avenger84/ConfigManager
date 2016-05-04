using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VNET.Library.ConfigManager.Interfaces;
using VNET.Library.Entities.CrmEntities;

namespace VNET.Library.ConfigManager
{
    public abstract class ConfigManager
    {
        private const int CACHE_INTERVAL = 10 * 1000;
        private System.Timers.Timer _timer;

        private static ConfigCollection _configCollection = new ConfigCollection();

        public ConfigManager()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = CACHE_INTERVAL;
            _timer.AutoReset = true;
        }

        public void StartConfigCache()
        {
            FillConfigValues();

            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FillConfigValues();
        }

        public void SetConfigValuesToCache(ConfigCollection configCollection)
        {
            _configCollection = configCollection;
        }

        public string GetValue(string key)
        {
            return _configCollection[key];
        }

        public abstract void FillConfigValues();
    }
}
